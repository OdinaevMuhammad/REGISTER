using System.IO.Enumeration;
namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class TodoListService
{
    private readonly DataContext _context;

    public TodoListService(DataContext context)
    {
        _context = context;
    }

    public async  Task<List<GetTodoList>> Get()
    {
        var list  = await _context.TodoList.Select(t => new GetTodoList()
        {
         Id = t.Id,
        Color = t.Color,
        Title = t.Title
        }).ToListAsync();

        return list;
    }
    
    public async Task<AddTodoList> Add(AddTodoList todoList)
    {
        var newTodoList =  new TodoList()
        {
            Color = todoList.Color,
            Title = todoList.Title
        
        };
        _context.TodoList.Add(newTodoList);
        await _context.SaveChangesAsync();

        return todoList;
    }
    public async Task<AddTodoList> Update(AddTodoList todoList)
    {
        var find = await _context.TodoList.FindAsync(todoList.Id);
        if(find == null ) return new AddTodoList();
    
       find.Title = todoList.Title;
       find.Color = todoList.Color;

        await _context.SaveChangesAsync();

        return todoList;
        
    }
  public async Task<string> Delete(int id)
    {
        var find = await _context.TodoList.FindAsync(id);
         _context.TodoList.Remove(find);

        await _context.SaveChangesAsync();
        return "Deleted";

    }

}