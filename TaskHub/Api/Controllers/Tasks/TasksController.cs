using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly IManageTaskUseCase _useCase;

    public TasksController(IManageTaskUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskResponse>> Get(Guid id, CancellationToken ct)
    {
        var result = await _useCase.GetTaskByIdAsync(id, ct);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id:guid}/title")]
    public async Task<IActionResult> SetTitle(Guid id, SetTaskTitleRequest request, CancellationToken ct)
    {
        await _useCase.SetTaskTitleAsync(id, request.Title!, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var deleted = await _useCase.DeleteTaskByIdAsync(id, ct);
        return deleted ? NoContent() : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll(CancellationToken ct)
    {
        await _useCase.DeleteAllTasksAsync(ct);
        return NoContent();
    }
}
