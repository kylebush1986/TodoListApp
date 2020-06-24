using System.Threading.Tasks;
using TodoListApp.API.Models;

namespace TodoListApp.API.Data
{
    public interface ITodoListRepository
    {
         Task<TodoList> CreateTodoList(int userId, TodoList todoList);
         Task<TodoList> GetTodoList(int todoListId);
         Task<TodoList> UpdateTodoList(int todoListId, TodoList todoList);
         Task<TodoList> DeleteTodoList(int todoListId);
    }
}