using Restaurants.Application;
using Restaurants.Infrastructure;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// app.Services is the dependency injection container in an ASP.NET Core application.
builder.Services.AddControllers();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog(((context, configuration) => configuration
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // coming directly from microsoft aspnet core, so we are narrow downing on that
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information) //information for entity framework core, useful fro debugging the application
    .WriteTo.Console(outputTemplate:"[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}")));

var app = builder.Build();

// Configure the HTTP request pipeline.

IServiceScope scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
await seeder.Seed();
// To capture the logs about our executed request we can use
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
