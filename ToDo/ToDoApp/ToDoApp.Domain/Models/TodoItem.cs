using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Models;

public class TodoItem
{
    public int Id { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "You need to add a title!")]
    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Assignee { get; set; } = default!;
    
    public int Priority { get; set; }
    
    public bool IsComplete { get; set; }
}