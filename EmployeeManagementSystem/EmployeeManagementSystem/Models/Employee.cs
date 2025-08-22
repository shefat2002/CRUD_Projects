using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models;

public class Employee
{
    
    public int Id { get; set; } //encapsulation (OOP)
    [Required(ErrorMessage = "Please Enter Employee Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please Enter Employee Email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please Enter Employee Phone Number")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Please Enter Employee Salary")]
    public int Salary { get; set; }

}

//Code-first Approach - Entity Framework Core (ORM)