using Domain;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;
using Domain.Entities;
public class DataContext:DbContext
{
 public DataContext(DbContextOptions<DataContext> options) : base(options)
 {

 }
 public DbSet<Todo> Todos {get; set;}
 public DbSet<TodoList> TodoList { get; set; }
 public DbSet<TodoListImage> TodoListImages { get; set; }
 public DbSet<Register> Registers { get; set; }

 
 
 

}