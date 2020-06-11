using BrennToDo.Data;
using BrennToDo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Repositories.ToDoRepositories
{
    public class DatabaseToDoReposity : IToDoRepository
    {

        private ToDoDbContext _context;
        private UserManager<ToDoUser> userManager;

        public DatabaseToDoReposity(ToDoDbContext context, UserManager<ToDoUser> userManager)
        {
            this._context = context;
            this.userManager = userManager;
        }

        public async Task<ToDo> DeleteToDo(string assignee, long id)
        {
            var todo = await _context.ToDo.FindAsync(id);
            if (todo == null)
            {
                return null;
            }

            var toDoToReturn = await GetOneToDo( assignee, id);

            _context.Remove(todo);

            await _context.SaveChangesAsync();

            return toDoToReturn;
        }

        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllToDoByUser(string userId)
        {

            var user = await userManager.FindByIdAsync(userId);

            var todos = await _context.ToDo
                .Where(td => td.CreatedByUserId != null && td.CreatedByUserId == userId)
                .Select(td => new ToDoDTO
                {
                    Title = td.Title,
                    Assignee = td.Assignee,
                    DueDate = td.DueDate,
                    Difficulty = td.Difficulty,
                    CreatedBy = user == null ? null : $"{user.FirstName} {user.LastName}"

                })
                .ToListAsync();

            return todos;
        }

        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            var toDoS = await _context.ToDo
                .Select(todo => new ToDo
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Assignee = todo.Assignee,
                    DueDate = todo.DueDate,
                    Difficulty = todo.Difficulty
                }
                ).ToListAsync();

            return toDoS;
        }

        public async Task<ToDo> GetOneToDo(string assignee, long id)
        {
            var toDo = await _context.ToDo
                .Where(todo => todo.Assignee == assignee)
                .Where(todo => todo.Id == id)
                .Select(todo => new ToDo
                    {
                        Id = todo.Id,
                        Title = todo.Title,
                        Assignee = todo.Assignee,
                        DueDate = todo.DueDate,
                        Difficulty = todo.Difficulty
                    }
                    ).FirstOrDefaultAsync();

            return toDo;
        }

        public async Task<IEnumerable<ToDo>> GetToDoByAssignee(string assignee)
        {
            var toDoS = await _context.ToDo
                .Where(todo => todo.Assignee == assignee)
              .Select(todo => new ToDo
              {
                  Id = todo.Id,
                  Title = todo.Title,
                  Assignee = todo.Assignee,
                  DueDate = todo.DueDate,
                  Difficulty = todo.Difficulty
              }
              ).ToListAsync();

            return toDoS;
        }

        public async Task<ToDo> GetToDoById(long id)
        {

            var toDo = await _context.ToDo
            .Where(todo => todo.Id == id)
            .Select(todo => new ToDo
            {
                Id = todo.Id,
                Title = todo.Title,
                Assignee = todo.Assignee,
                DueDate = todo.DueDate,
                Difficulty = todo.Difficulty
            }
            ).FirstOrDefaultAsync();

            return toDo;
        }

        public async Task<ToDo> SaveNewTodo(ToDo toDo)
        {
          
            _context.Add(toDo);
            await _context.SaveChangesAsync();

            return toDo;
        }

        public async Task<bool> UpdateToDo(string assignee, long id, object todo)
        {
            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }

            }
        }

        private bool ToDoExists(long id)
        {
            return _context.ToDo.Any(e => e.Id == id);
        }
    }
}
