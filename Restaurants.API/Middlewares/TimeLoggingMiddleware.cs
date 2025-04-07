using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class TimeLoggingMiddleware(ILogger<TimeLoggingMiddleware> logger): IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            var stopwatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopwatch.Stop();
            var path = context.Request.Path;
            var verb = context.Request.Method;
            if(stopwatch.ElapsedMilliseconds/1000 > 4)
                logger.LogInformation($"Request:has {verb} at {path} took{ stopwatch.ElapsedMilliseconds} ms");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}