using Restaurants.Application;
using Restaurants.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// app.Services is the dependency injection container in an ASP.NET Core application.
builder.Services.AddControllers();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

IServiceScope scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
await seeder.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
