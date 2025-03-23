using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants.Services;
using Restaurants.Application.Restaurants.Services.Interfaces;

namespace Restaurants.Application;

public static class ApplicationExtensions
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        
        services.AddAutoMapper(typeof(ApplicationExtensions).Assembly);
    }
}