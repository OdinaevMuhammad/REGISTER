namespace Infrastructure.Services;
using Infrastructure.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
public class TodoService
{
    public readonly DataContext _context;
    public TodoService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTodoDto>> GetTodos()
    {
       var list  = await _context.Todos.Select(t => new GetTodoDto()
        {
            Id = t.Id,
            Description = t.Description,
            Status = t.Status.ToString(),
            Title = t.Title,
            CreatedAt = t.CreatedAt,
            TodoListTitle = t.TodoList.Title,
            TodoListColor = t.TodoList.Color
        
            
        }).ToListAsync();
        
        return list;
    }
    public async Task<AddTodo> Add(AddTodo todo)
    {
        var newTodo = new Todo()
        {
            Description = todo.Description,
            Status = todo.Status,
            Title = todo.Title,
            CreatedAt = DateTime.UtcNow,
            TodoListId = todo.TodoListId,

        };
        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();
        return todo;
    }
    public async Task<AddTodo> Update(AddTodo todo)
    {
        var find = await _context.Todos.FindAsync(todo.Id);

        if(find == null) return new AddTodo();
        find.Title = todo.Title;
        find.Description = todo.Description;
        find.CreatedAt = todo.CreatedAt;
        find.Status = todo.Status;
        await _context.SaveChangesAsync();
        return todo;
    }
    public async Task<string> Delete(int id)
    {
        var find = await _context.Todos.FindAsync(id);
         _context.Todos.Remove(find);
        await _context.SaveChangesAsync();
        return "Deleted";

    }
}