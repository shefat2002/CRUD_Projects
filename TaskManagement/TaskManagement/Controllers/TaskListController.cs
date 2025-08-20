using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Controllers;

public class TaskListController : Controller
{
    private readonly TaskDbContext _dbContext;

    public TaskListController(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var tasks = _dbContext.Tasks.ToList();
        return View(tasks);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(TaskList task)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Tasks.Add(task);
            if (_dbContext.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to create task. Please try again.");
        }
        return View(task);
    }
}