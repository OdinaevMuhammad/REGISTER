namespace Domain.Entities;

public class TodoList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    public virtual List<Todo> Todos { get; set; }
    public virtual List<TodoListImage> TodoListImage { get; set; }
    
    
}