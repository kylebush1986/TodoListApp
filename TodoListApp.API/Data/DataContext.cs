using Microsoft.EntityFrameworkCore;
using TodoListApp.API.Models;

namespace TodoListApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<TodoList> TodoLists{ get; set; }
        public DbSet<Todo> Todo { get; set; }
    }
}