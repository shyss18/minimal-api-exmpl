namespace MiddlewareExmpl.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occured: {e.Message}{e.StackTrace}");
            if (e.InnerException is not null)
            {
                Console.WriteLine($"Inner Exception: {e.InnerException?.Message}");
            }
            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An exception occured.");
        }
    }
}