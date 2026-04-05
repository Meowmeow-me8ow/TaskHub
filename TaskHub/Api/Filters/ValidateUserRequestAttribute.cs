using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Api.Filters
{
    public class ValidateUserRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.ActionArguments.Values.FirstOrDefault();

            if (request == null)
            {
                context.Result = new BadRequestObjectResult("нет тела запроса");
                return;
            }

            var nameProperty = request.GetType().GetProperty("Name");

            if (nameProperty == null)
            {
                return;
            }

            var nameValue = nameProperty.GetValue(request)?.ToString();

            if (string.IsNullOrWhiteSpace(nameValue))
            {
                context.Result = new BadRequestObjectResult("нет имени");
            }
        }
    }
}
