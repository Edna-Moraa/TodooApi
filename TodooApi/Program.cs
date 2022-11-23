using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


Console.WriteLine(builder.Configuration["SystemConnection"]);
builder.Services.AddDbContext<TodoContext>(options =>
        options.UseSqlServer("Server=MABURI;Database=TodoDb;Trusted_Connection=True;"));
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

    

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();