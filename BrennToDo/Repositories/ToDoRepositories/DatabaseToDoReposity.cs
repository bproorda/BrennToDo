using BrennToDo.Data;
using BrennToDo.Models;
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

        public DatabaseToDoReposity(ToDoDbContext context)
        {
            this._context = context;
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

        public async Task<ToDo> SaveNewTodo(string assignee, CreateToDo toDo)
        {
            var newTodo = new ToDo
            {
                Id = toDo.Id,
                Assignee = toDo.Assignee,
                Title = toDo.Title,
                Difficulty = toDo.Difficulty,
                DueDate = toDo.DueDate
            };

            _context.Add(newTodo);
            await _context.SaveChangesAsync();

            return newTodo;
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
