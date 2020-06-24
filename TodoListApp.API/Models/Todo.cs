using System;

namespace TodoListApp.API.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}