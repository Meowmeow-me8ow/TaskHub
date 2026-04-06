using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ValidateCreateTaskRequestFilter : Attribute, IActionFilter
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

        var request = requestObj as CreateTaskRequest;
        if (request == null)
        {
            context.Result = new BadRequestObjectResult("тело запроса отсутствует");
            return;
        }

        if (request.UserId == Guid.Empty)
        {
            context.Result = new BadRequestObjectResult("идентификатор пользователя не задан");
            return;
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            context.Result = new BadRequestObjectResult("название задачи не задано");
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}