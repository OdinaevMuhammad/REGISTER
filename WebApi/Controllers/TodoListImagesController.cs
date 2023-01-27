using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TodoListImageController
{
    private readonly TodoListImageService _TodoListImageService;

    public TodoListImageController(TodoListImageService todoListImageService)
    {
        _TodoListImageService = todoListImageService;
    }
    
    [HttpGet]
    public async Task<List<GetTodoListImage>> Get()
    {
        return  await _TodoListImageService.Get();
    }
    [HttpPost("Register")]
    public async Task<Response<RegisterDto>> Register(RegisterDto register)
    {
        return await _TodoListImageService.Register(register);
    }
    [HttpGet("LogIn")]
    public async Task<Response<string>> LogIn(string phoneNumber, string password)
    {
        return await _TodoListImageService.LogIn(phoneNumber,password);
    }
    [HttpPost]
    public async Task<AddTodoListImage> Post(AddTodoListImage TodoListImage)
    {
        return await _TodoListImageService.Add(TodoListImage);
    }
    [HttpPut]
    public async Task<AddTodoListImage> Update(AddTodoListImage TodoListImage)
    {
        return await _TodoListImageService.Update(TodoListImage);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _TodoListImageService.Delete(id);
    }
   
    
}