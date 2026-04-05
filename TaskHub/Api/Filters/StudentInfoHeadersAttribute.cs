using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class StudentInfoHeadersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            headers["X-Student-Name"] = "Tumashova Marina";
            headers["X-Student-Group"] = "RI-240912";
        }
    }
}
