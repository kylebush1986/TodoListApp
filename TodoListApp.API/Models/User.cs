using System.Collections.Generic;

namespace TodoListApp.API.Models
{
    public class User
    {
        public User()
        {
            TodoLists = new List<TodoList>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt  { get; set; }
        public List<TodoList> TodoLists { get; set; }
    }
}