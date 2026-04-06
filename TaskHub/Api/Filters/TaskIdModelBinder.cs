using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Filters;

public class TaskIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var value = bindingContext.ValueProvider.GetValue("id");

        if (value == ValueProviderResult.None)
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        var idString = value.FirstValue;

        if (string.IsNullOrWhiteSpace(idString))
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        if (!Guid.TryParse(idString, out var guid))
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи имеет некорректный формат");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(guid);
        return Task.CompletedTask;
    }
}