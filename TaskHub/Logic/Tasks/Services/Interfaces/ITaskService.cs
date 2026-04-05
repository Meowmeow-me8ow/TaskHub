using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;

namespace Logic.Tasks.Services.Interfaces;

public interface ITaskService
{
    Task<TaskEntity> CreateTaskAsync(string? title, Guid userId, CancellationToken cancellationToken);

    Task<List<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken);

    Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);

    Task SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken);

    Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}
