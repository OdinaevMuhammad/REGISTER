using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TodoListController
{
    private readonly TodoListService _TodoListService;

    public TodoListController(TodoListService TodoListService)
    {
        _TodoListService = TodoListService;
    }
    
    [HttpGet]
    public async Task<List<GetTodoList>> Get()
    {
        return  await _TodoListService.Get();
    }
    
    [HttpPost]
    public async Task<AddTodoList> Post(AddTodoList TodoList)
    {
        return await _TodoListService.Add(TodoList);
    }
    [HttpPut]
    public async Task<AddTodoList> Update(AddTodoList TodoList)
    {
        return await _TodoListService.Update(TodoList);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _TodoListService.Delete(id);
    }
   
    
}