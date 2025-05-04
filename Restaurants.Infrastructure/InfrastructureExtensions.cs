using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Repositories;

namespace Restaurants.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("RestaurantsDb"))
            .EnableSensitiveDataLogging());

        services.AddScoped<ISeeder, Seeder.Seeder>();   // add dbcontext adds the db context as coped dependency by default so we also do that for the seeder
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();
    }
    
}