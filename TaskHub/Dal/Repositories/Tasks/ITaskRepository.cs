using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;

namespace Dal.Repositories.Tasks
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateAsync(TaskEntity task);
        Task<List<TaskEntity>> GetAllAsync();
        Task<TaskEntity?> GetByIdAsync(Guid id);
        Task UpdateTitleAsync(Guid id, string title);
        Task<bool> DeleteAsync(Guid id);
        Task DeleteAllAsync();
    }
}
