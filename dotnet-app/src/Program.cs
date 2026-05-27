var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new
{
    app     = "dotnet-app",
    status  = "running",
    version = "1.0.0",
    time    = DateTime.UtcNow
});

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.MapGet("/ready", () => Results.Ok(new { status = "ready" }));

app.Run();