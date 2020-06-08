using BrennToDo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrennToDo.Repositories.ToDoRepositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllToDos();
        Task<ToDo> GetToDoById(long id);
        Task<IEnumerable<ToDo>> GetToDoByAssignee(string assignee);
        Task<ToDo> GetOneToDo(string assignee, long id);
        Task<bool> UpdateToDo(string assignee, long id, object todo);
        Task<ToDo> SaveNewTodo(string assignee, CreateToDo toDo);
    }
}
