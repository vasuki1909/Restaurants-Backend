using Restaurants.Application.Exceptions;
namespace Restaurants.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) :IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException exception)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(exception.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            context.Response.StatusCode = 500;
            //await context.Response.WriteAsync("Something went wrong!!");
        }
    }
}