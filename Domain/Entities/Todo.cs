namespace Domain.Entities;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public int TodoListId { get; set; }
    public virtual TodoList TodoList { get; set; }
    
    
}
  public enum Status
    {
        Todo,
        InProgress,
        Completed
    };
    