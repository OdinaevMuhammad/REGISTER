using Domain.Entities;

public class TodoListImage
{

    public int Id { get; set; }
    public string ImageName { get; set; }
    public int TodoListId { get; set; }
    public virtual TodoList TodoList {get; set;}

}