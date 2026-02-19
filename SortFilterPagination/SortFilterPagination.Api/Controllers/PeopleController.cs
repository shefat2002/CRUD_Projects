using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SortFilterPagination.Data;
using SortFilterPagination.Models;
using SortFilterPagination.Queries;

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
    public async Task<ActionResult<PagedResult<Person>>> GetPeople([FromQuery] QueryParameters query)
    {
        var dbQuery = _context.People.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.City))
        {
            dbQuery = dbQuery.Where(p => p.City == query.City);
        }

        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var term = query.SearchTerm.ToLower();
            dbQuery = dbQuery.Where(p => 
                p.FirstName.ToLower().Contains(term) || 
                p.LastName.ToLower().Contains(term) ||
                p.Email.ToLower().Contains(term));
        }

        dbQuery = query.SortOrder?.ToLower() == "desc" 
            ? SortDesc(dbQuery, query.SortColumn) 
            : SortAsc(dbQuery, query.SortColumn);

        var totalCount = await dbQuery.CountAsync();
        
        var items = await dbQuery
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return new PagedResult<Person>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        };
    }

    [HttpGet("cities")]
    public async Task<ActionResult<List<string>>> GetCities()
    {
        return await _context.People
            .Select(p => p.City)
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();
    }

    private static IQueryable<Person> SortAsc(IQueryable<Person> query, string? col) => col?.ToLower() switch
    {
        "firstname" => query.OrderBy(p => p.FirstName),
        "lastname" => query.OrderBy(p => p.LastName),
        "email" => query.OrderBy(p => p.Email),
        "age" => query.OrderBy(p => p.Age),
        "city" => query.OrderBy(p => p.City),
        _ => query.OrderBy(p => p.Id)
    };

    private static IQueryable<Person> SortDesc(IQueryable<Person> query, string? col) => col?.ToLower() switch
    {
        "firstname" => query.OrderByDescending(p => p.FirstName),
        "lastname" => query.OrderByDescending(p => p.LastName),
        "email" => query.OrderByDescending(p => p.Email),
        "age" => query.OrderByDescending(p => p.Age),
        "city" => query.OrderByDescending(p => p.City),
        _ => query.OrderByDescending(p => p.Id)
    };
}
