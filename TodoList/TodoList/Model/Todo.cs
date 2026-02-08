using System.ComponentModel.DataAnnotations;

namespace TodoList.Model;

public class Todo
{
    public int Id { get; set; }

    [StringLength(15, ErrorMessage = "Error! Title must be within 15 characters!")]
    public string TaskTitle { get; set; } = null!;
    
    [StringLength(45, ErrorMessage = "Error! Description must be within 45 characters!")]
    public string Description { get; set; } = null!;
    public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; } = DateTime.UtcNow;
    public Priority Priority { get; set; }

}

public enum Priority
{
    High,
    Low
}