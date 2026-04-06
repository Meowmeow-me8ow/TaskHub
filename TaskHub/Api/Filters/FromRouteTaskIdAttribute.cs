using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
public class FromRouteTaskIdAttribute : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.RouteData.Values.TryGetValue("id", out var idObj))
        {
            context.Result = new BadRequestObjectResult("Идентификатор задачи не задан");
            return;
        }

        string? idString = idObj?.ToString();

        if (string.IsNullOrWhiteSpace(idString))
        {
            context.Result = new BadRequestObjectResult("Идентификатор задачи не задан");
            return;
        }

        if (!Guid.TryParse(idString, out var guid))
        {
            context.Result = new BadRequestObjectResult("Идентификатор задачи имеет некорректный формат");
            return;
        }

        context.HttpContext.Items["TaskId"] = guid;
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}