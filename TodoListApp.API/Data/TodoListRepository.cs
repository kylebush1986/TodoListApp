using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.API.Models;

namespace TodoListApp.API.Data
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly DataContext _context;

        public TodoListRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<TodoList> CreateTodoList(int userId, TodoList todoList)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) {
                return null;
            }

            user.TodoLists.Add(todoList);
            _context.Users.Update(user);
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();

            return todoList;
        }

        public async Task<TodoList> DeleteTodoList(int todoListId)
        {
            var todoList = await _context.TodoLists.FirstOrDefaultAsync(t => t.Id == todoListId);

            if (todoList == null)
            {                
                return null;
            }

            _context.Remove(todoList);
            await _context.SaveChangesAsync();

            return todoList;
        }

        public async Task<TodoList> GetTodoList(int todoListId)
        {
            return await _context.TodoLists.FirstOrDefaultAsync(t => t.Id == todoListId);
        }

        public async Task<TodoList> UpdateTodoList(int todoListId, TodoList todoList)
        {
            var existingTodoList = await _context.TodoLists.FirstOrDefaultAsync(t => t.Id == todoListId);

            if (existingTodoList == null) 
            {
                return null;
            }

            _context.TodoLists.Update(existingTodoList);
            existingTodoList = todoList;
            await _context.SaveChangesAsync();

            return todoList;
        }
    }
}