using System.ComponentModel.DataAnnotations;
using ToDoApp.Domain.Models;

namespace ToDoApp.Api.Filters;

public class CreateTodoFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var todoItem = context.GetArgument<TodoItem>(0);
        if (todoItem.Assignee == "Joe Bloggs")
        {
            return Results.Problem("Joe Bloggs cannot be assigned a todoitem");
        }

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(todoItem);

        var isValid = Validator.TryValidateObject(todoItem, validationContext, validationResults, true);
        if (!isValid)
        {
            return Results.BadRequest(validationResults);
        }

        return await next(context);
    }
}