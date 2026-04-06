using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.Filters;
using Api.UseCases.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

[Route("tasks")]
[StudentInfoHeadersFilter]
[RequestLoggingFilter]
public class TasksController : ControllerBase
{
    private readonly IManageTaskUseCase _useCase;

    public TasksController(IManageTaskUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    [ValidateCreateTaskRequestFilter]
    public async Task<ActionResult<TaskResponse>> Create(CreateTaskRequest request, CancellationToken ct)
    {
        var result = await _useCase.CreateTaskAsync(request.Title, request.UserId, ct);
        return Created("", result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetAll(CancellationToken ct)
    {
        return Ok(await _useCase.GetAllTasksAsync(ct));
    }

    [HttpGet("{id}")]
    [FromRouteTaskId]
    public async Task<ActionResult<TaskResponse>> Get(
        [FromRouteTaskId] string id,
        CancellationToken ct)
    {
        var guidObj = HttpContext.Items["TaskId"];

        if (guidObj == null)
        {
            return BadRequest("Идентификатор задачи не задан");
        }

        var guid = (Guid)guidObj;
        var result = await _useCase.GetTaskByIdAsync(guid, ct);

        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}/title")]
    [FromRouteTaskId]
    [ValidateSetTaskTitleRequestFilter]
    public async Task<IActionResult> SetTitle(
        [FromRouteTaskId] string id,
        SetTaskTitleRequest request,
        CancellationToken ct)
    {
        var guidObj = HttpContext.Items["TaskId"];

        if (guidObj == null)
        {
            return BadRequest("Идентификатор задачи не задан");
        }

        var guid = (Guid)guidObj;
        await _useCase.SetTaskTitleAsync(guid, request.Title!, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [FromRouteTaskId]
    public async Task<IActionResult> Delete(
        [FromRouteTaskId] string id,
        CancellationToken ct)
    {
        var guidObj = HttpContext.Items["TaskId"];

        if (guidObj == null)
        {
            return BadRequest("Идентификатор задачи не задан");
        }

        var guid = (Guid)guidObj;
        var deleted = await _useCase.DeleteTaskByIdAsync(guid, ct);
        return deleted ? NoContent() : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll(CancellationToken ct)
    {
        await _useCase.DeleteAllTasksAsync(ct);
        return NoContent();
    }
}