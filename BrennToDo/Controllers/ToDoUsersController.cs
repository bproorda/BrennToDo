using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrennToDo.Models;
using BrennToDo.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrennToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoUsersController : ControllerBase
    {
        private readonly UserManager<ToDoUser> userManager;

        public ToDoUsersController(UserManager<ToDoUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult>  Register(RegisterData data)
        {
            var newUser = new ToDoUser
            {
                UserName = data.UserName,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email
            };
            var result = await userManager.CreateAsync(newUser, data.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Registration failed",
                    errors = result.Errors,
                });
            }

            return Ok(new UserWithToken
            {
                UserId = user.Id,
                Token = userManager.CreateToken(user),
            });
        }
    }
}