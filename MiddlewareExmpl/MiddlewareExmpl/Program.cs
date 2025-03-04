using MiddlewareExmpl.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var blockedIps = new List<string>();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<IpBlockingMiddleware>(blockedIps);

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", () =>
{
    throw new NotImplementedException();
});

app.Run();
