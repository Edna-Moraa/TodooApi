using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));



builder.Services.AddDbContext<TodoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Data:SystemConnection: ConnectionStrings")));
//builder.Services.AddSwaggerGen(c =>
//{C:\Users\VOSTRO\source\repos\TodooApi\TodooApi\bin\Debug\net6.0\appsetings.json
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

    

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();