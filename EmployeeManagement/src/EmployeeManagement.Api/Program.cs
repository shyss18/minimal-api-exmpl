using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/employees/{id}", (int id) =>
{
    var employee = EmployeeManager.Get(id);
    return Results.Ok(employee);
});

app.MapPost("/employees", (Employee employee) =>
{
    EmployeeManager.Create(employee);
    return Results.Created();
});

app.MapPut("/employees", (Employee employee) =>
{
    EmployeeManager.Update(employee);
    return Results.Ok();
});

app.MapPatch("/update-employee-name", (Employee employee) =>
{
    EmployeeManager.ChangeName(employee);
    return Results.Ok();
});

app.MapDelete("/employees/{id}", (int id) =>
{
    EmployeeManager.Delete(id);
    return Results.Ok();
});

app.Run();