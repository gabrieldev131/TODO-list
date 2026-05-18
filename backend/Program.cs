using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.Api.Domain.Commands;
using TodoList.Api.Domain.Entities;
using TodoList.Api.Domain.Factories;
using TodoList.Api.Domain.Interfaces;
using TodoList.Api.Domain.Strategies;
using TodoList.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Core Services Registration (SOLID: Dependency Inversion)
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddSingleton<ITaskFactory, SimpleTaskFactory>();
builder.Services.AddSingleton<TaskSortingContext>();

// Command Handlers Registration
builder.Services.AddTransient<ITaskCommandHandler<RegisterTaskCommand, TodoList.Api.Domain.Entities.Task>, RegisterTaskCommandHandler>();
builder.Services.AddTransient<ITaskCommandHandler<RemoveTaskCommand>, RemoveTaskCommandHandler>();

// Aggregated Dependencies (Object Calisthenics: Max 2 instance variables per class)
builder.Services.AddTransient<TaskCommandHandlerBundle>();

// CORS configuration for React Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("https://todo-list-frontend-hc33.onrender.com") // Vite default port
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
