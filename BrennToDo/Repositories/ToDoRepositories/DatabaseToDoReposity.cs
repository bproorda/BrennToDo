﻿using BrennToDo.Data;
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
        private bool ToDoExists(long id)
        {
            return _context.ToDo.Any(e => e.Id == id);
        }
    }
}
