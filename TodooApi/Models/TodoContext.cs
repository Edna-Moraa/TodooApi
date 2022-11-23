using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;


namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

       
    public DbSet<TodoTable>TodoTables { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
}
}