using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class StudentInfoHeadersFilter : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Response.Headers.Append("X-Student-Name", "Tumashova Marina");
        context.HttpContext.Response.Headers.Append("X-Student-Group", "RI-240912");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}