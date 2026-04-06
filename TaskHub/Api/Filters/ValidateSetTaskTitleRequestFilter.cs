using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ValidateSetTaskTitleRequestFilter : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue("request", out var requestObj))
        {
            context.Result = new BadRequestObjectResult("тело запроса отсутствует");
            return;
        }

        if (requestObj == null)
        {
            context.Result = new BadRequestObjectResult("тело запроса отсутствует");
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}