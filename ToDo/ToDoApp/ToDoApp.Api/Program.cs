using System.ComponentModel.DataAnnotations;
using ToDoApp.Api.Filters;
using ToDoApp.Domain.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todoItems = new List<TodoItem>();

app.MapGet("/todo-items", () => Results.Ok(todoItems));

app.MapGet("/todo-items/{id:int}", (int id) =>
{
    var index = todoItems.FindIndex(x => x.Id == id);
    return index == -1 ? Results.NotFound() : Results.Ok(todoItems[index]);
});

app.MapPost("/todo-items", (TodoItem item) =>
{
    todoItems.Add(item);
    return Results.Created();
}).AddEndpointFilter<CreateTodoFilter>();

app.MapPut("/todo-items", (TodoItem item) =>
{
    var index = todoItems.FindIndex(x => x.Id == item.Id);
    if (index == -1)
    {
        return Results.NotFound();
    }

    todoItems[index] = item;
    return Results.NoContent();
});

app.MapPatch("/updateTodoItemDueDate/{id:int}",
    (int id, DateTime newDueDate) =>
    {
        var index = todoItems.FindIndex(x => x.Id == id);
        if (index == -1)
        {
            return Results.NotFound();
        }

        todoItems[index].DueDate = newDueDate;
        return Results.NoContent();
    });

app.MapDelete("/todo-items/{id:int:range(1,100)}", (int id) =>
{
    var index = todoItems.FindIndex(x => x.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }

    todoItems.RemoveAt(index);
    return Results.NoContent();
});

app.Run();