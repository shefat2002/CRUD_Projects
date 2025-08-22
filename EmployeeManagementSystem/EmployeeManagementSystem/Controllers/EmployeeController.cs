using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeDbContext _context;
    public EmployeeController(EmployeeDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return View(employees);
    }

    [HttpGet] // Specifies that this action handles GET requests
    public IActionResult Create()
    {
        return View();
    }
    

    [HttpPost]// Specifies that this action handles POST requests
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(employee);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                ModelState.AddModelError("", "Failed to create employee. Please try again.");
            }
        }
        return View(employee);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee); //ok(200)
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Update(employee);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to update employee. Please try again.");
            }
        }
        return View(employee);
    }
    
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        _context.Employees.Remove(employee);
        var result = _context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return BadRequest("Failed to delete employee. Please try again.");
        }
    }
}

