using System.ComponentModel.DataAnnotations;

namespace TodoList.Model.DTOs;

public class UpdateTodoDto
{
    [StringLength(15, ErrorMessage = "Error! Title must be within 15 characters!")]
    public string Title { get; set; } = null!;
    [StringLength(45, ErrorMessage = "Error! Description must be within 45 characters!")]
    public string Description { get; set; } = null!;

    public bool IsCompleted { get; set; } = false;
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
}