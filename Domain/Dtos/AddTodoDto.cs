namespace Domain.Entities;

public class AddTodo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public int TodoListId { get; set; }
    public string  Color { get; set; }
}