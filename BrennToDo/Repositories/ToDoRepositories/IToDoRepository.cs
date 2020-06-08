using BrennToDo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Repositories.ToDoRepositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllToDos();
    }
}
