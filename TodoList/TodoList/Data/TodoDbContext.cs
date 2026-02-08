using Microsoft.EntityFrameworkCore;
using TodoList.Model;

namespace TodoList.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext (DbContextOptions<TodoDbContext> options) : base(options) {
    }
    public DbSet<Todo> Tasks { get; set; }

}