using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrennToDo.Data;
using BrennToDo.Models;
using BrennToDo.Repositories.ToDoRepositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BrennToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        IToDoRepository toDoRepository;

        public object ClaimType { get; private set; }

        public ToDoController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo()
        {
            return await toDoRepository.GetAllToDoByUser(GetUserId());
        }

       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo()
        {
            return Ok(await toDoRepository.GetAllToDos());
        }*/

        // GET: api/ToDoes/5
        [HttpGet("ById/{id}")]
        public async Task<ActionResult<ToDo>> GetToDoById(long id)
        {
            var toDo = await toDoRepository.GetToDoById(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        [HttpGet("{assignee}")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDoByAssignee(string assignee)
        {
            var toDo = Ok(await toDoRepository.GetToDoByAssignee(assignee));

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        [HttpGet("{assignee}/{id}")]
        public async Task<ActionResult<ToDo>> GetOneToDo(string assignee, long id)
        {
            var toDo = await toDoRepository.GetOneToDo(assignee, id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }


        // PUT: api/ToDoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{assignee}/{id}")]
        public async Task<IActionResult> PutToDo(string assignee, long id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await toDoRepository.UpdateToDo(assignee, id, toDo);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/ToDo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        //Refactoring to require a logged in user to post
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo([FromBody], CreateToDo toDo)
        {
            await toDoRepository.SaveNewTodo(assignee, toDo);

            return CreatedAtAction("GetToDoById", new { id = toDo.Id }, toDo);
        }

        
        // DELETE: api/ToDoes/5
        [HttpDelete("{assignee}/{id}")]
        public async Task<ActionResult<ToDo>> DeleteToDo(string assignee, long id)
        {
            var toDo = await toDoRepository.DeleteToDo(assignee, id);
            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        private string GetUserId()
        {
            return ((ClaimsIdentity)User.Identity).FindFirst("UserId")?.Value;
        }


    }
}
