using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Model;
using TodoList.Model.DTOs;

namespace TodoList.Controllers;

[ApiController]
[Route("api/Controller")]
public class TasksController(TodoDbContext context) : Controller
{
    private readonly TodoDbContext _context = context;
    
    // POST 
    public async Task<ActionResult<Task>> CreateTask(CreateTodoDto dto)
    {
        var todo = new Todo
        {
            TaskTitle = dto.Title,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow,
            DueDate = dto.DueDate
            
        };
        _context.Tasks.Add(todo);
        await _context.SaveChangesAsync();
        return Ok();
    }
    // GET
    // public async Task<ActionResult<IEnumerable<Task>>> GetTaskList()
    // {
    //     
    // }
}