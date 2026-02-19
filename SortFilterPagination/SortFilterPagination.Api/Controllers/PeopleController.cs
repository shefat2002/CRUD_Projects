using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SortFilterPagination.Data;
using SortFilterPagination.Models;

namespace SortFilterPagination.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly AppDbContext _context;

    public PeopleController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetPeople()
    {
        return await _context.People.ToListAsync();
    }
}
