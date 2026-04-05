using Dal.Entities;
using Dal.Repositories.Interfaces;
using Dal.Repositories.Tasks;
using Logic.Tasks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tasks.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public Task<TaskEntity> CreateTaskAsync(string? title, Guid userId, CancellationToken cancellationToken)
        => _repo.CreateAsync(new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            CreatedByUserId = userId,
            CreatedUtc = DateTimeOffset.UtcNow
        });

    public Task<List<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken)
        => _repo.GetAllAsync();

    public Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
        => _repo.GetByIdAsync(id);

    public Task SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken)
        => _repo.UpdateTitleAsync(id, title);

    public Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken)
        => _repo.DeleteAsync(id);

    public Task DeleteAllTasksAsync(CancellationToken cancellationToken)
        => _repo.DeleteAllAsync();
}
