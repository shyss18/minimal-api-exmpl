namespace MiddlewareExmpl.Middlewares;

public class IpBlockingMiddleware
{
    private readonly HashSet<string> _blockedIps;
    private readonly RequestDelegate _next;

    public IpBlockingMiddleware(RequestDelegate next, IEnumerable<string> blockedIps)
    {
        _next = next;
        _blockedIps = new HashSet<string>(blockedIps);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestIpAddress = context.Connection.RemoteIpAddress?.ToString();
        if (_blockedIps.Contains(requestIpAddress!))
        {
            context.Response.StatusCode = 403;

            Console.WriteLine($"IP Address {requestIpAddress}, is not allowed.");
            
            await context.Response.WriteAsync("Your IP is blocked.");
            
            return;
        }

        Console.WriteLine($"IP Address {requestIpAddress} is allowed.");
        
        await _next(context);
    }
}