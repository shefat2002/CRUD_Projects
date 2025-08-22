using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models;

public class Employee
{
    
    public int Id { get; set; } //encapsulation (OOP)
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public int Salary { get; set; }

}

//Code-first Approach - Entity Framework Core (ORM)