using System.IO.Enumeration;
namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Infrastructure.ServiceProfile;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

public class TodoListImageService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public TodoListImageService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<RegisterDto>> Register(RegisterDto register)
    {
        try
        {
            var mapped = _mapper.Map<Register>(register);
            await _context.Registers.AddAsync(mapped);
            await _context.SaveChangesAsync();
            register.Id = mapped.Id;
            return new Response<RegisterDto>(register);
        }
        catch (System.Exception ex)
        {
            return new Response<RegisterDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> LogIn(string phoneNumber, string password)
    {
        try
        {
            var check = await _context.Registers.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber && x.Password == password);
            if (check == null) return new Response<string>(System.Net.HttpStatusCode.BadRequest, "PhoneNumber or Password is incorrect");


            return new Response<string>(System.Net.HttpStatusCode.OK, "You are Login");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<List<GetTodoListImage>> Get()
    {
        var list = await _context.TodoListImages.Select(t => new GetTodoListImage()
        {
            Id = t.Id,
            ImageName = t.ImageName,
            Title = t.TodoList.Title,
            Color = t.TodoList.Color
        }).ToListAsync();

        return list;
    }


    public async Task<AddTodoListImage> Add(AddTodoListImage todoListImage)
    {
        var newTodoListImageList = new TodoListImage()
        {
            ImageName = todoListImage.ImageName,
            TodoListId = todoListImage.TodoListId
        };
        _context.TodoListImages.Add(newTodoListImageList);
        await _context.SaveChangesAsync();

        return todoListImage;
    }
    public async Task<AddTodoListImage> Update(AddTodoListImage todoListImage)
    {
        var find = await _context.TodoListImages.FindAsync(todoListImage.Id);
        if (find == null) return new AddTodoListImage();

        find.ImageName = todoListImage.ImageName;
        find.TodoListId = todoListImage.TodoListId;

        await _context.SaveChangesAsync();

        return todoListImage;

    }
    public async Task<string> Delete(int id)
    {
        var find = await _context.TodoListImages.FindAsync(id);
        _context.TodoListImages.Remove(find);

        await _context.SaveChangesAsync();
        return "Deleted";

    }

}