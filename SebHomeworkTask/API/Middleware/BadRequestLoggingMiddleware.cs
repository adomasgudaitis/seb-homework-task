namespace SebHomeworkTask.API.Middleware;

public class BadRequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<BadRequestLoggingMiddleware> _logger;

    public BadRequestLoggingMiddleware(RequestDelegate next, ILogger<BadRequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
        {
            _logger.Log(LogLevel.Error, $"Bad Request: {context.Response.StatusCode} - {context.Request.Path}");
        }
    }
}

public static class BadRequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseBadRequestLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<BadRequestLoggingMiddleware>();
    }
}