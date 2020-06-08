using BrennToDo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrennToDo.Repositories.ToDoRepositories
{
    public class DatabaseToDoReposity : IToDoRepository
    {
        public Task<IEnumerable<ToDo>> GetAllToDos()
        {
            throw new NotImplementedException();
        }
    }
}
