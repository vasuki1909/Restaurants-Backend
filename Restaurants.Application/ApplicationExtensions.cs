using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurants.Application;

public static class ApplicationExtensions
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddAutoMapper(typeof(ApplicationExtensions).Assembly);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation(); 
        // What Happens If You Only Use AddValidatorsFromAssembly()?
        // It registers validators in the Dependency Injection (DI) container.
        // 
        // But it does not automatically integrate FluentValidation with ASP.NET Core's model validation.
        // 
        // So, you must manually call _validator.Validate(model) in your controller.
        // 
       // ✔ Adding AddFluentValidationAutoValidation() → FluentValidation automatically validates models before controller actions.
        // 
    }
}