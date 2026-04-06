using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Api.Filters;

public class RequestLoggingFilter : Attribute, IActionFilter
{
    private Stopwatch _stopwatch;
    private ILogger _logger;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger<RequestLoggingFilter>();

        _stopwatch = Stopwatch.StartNew();
        var httpMethod = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;

        _logger.LogInformation("начало выполнения: {Method} {Path}", httpMethod, path);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        var statusCode = context.HttpContext.Response.StatusCode;
        var elapsedMs = _stopwatch.ElapsedMilliseconds;

        _logger.LogInformation("завершение: статус {StatusCode}, время {ElapsedMs} мс", statusCode, elapsedMs);
    }
}