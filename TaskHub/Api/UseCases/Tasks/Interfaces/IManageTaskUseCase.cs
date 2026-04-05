using Api.Controllers.Tasks.Response;

namespace Api.UseCases.Tasks.Interfaces
{
    public interface IManageTaskUseCase
    {
        Task<TaskResponse> CreateTaskAsync(string? title, Guid userId, CancellationToken cancellationToken);

        Task<IReadOnlyList<TaskResponse>> GetAllTasksAsync(CancellationToken cancellationToken);

        Task<TaskResponse?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);

        Task SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken);

        Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken);

        Task DeleteAllTasksAsync(CancellationToken cancellationToken);
    }
}
