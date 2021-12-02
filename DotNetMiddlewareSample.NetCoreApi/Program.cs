using DotNetMiddlewareSample.NetCoreApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.ConfigureServices(services =>
{
    services.AddSwaggerDocument();
    services.AddRouting(options => options.LowercaseUrls = true);
    services.AddControllers();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseLogging();

app.Run();
