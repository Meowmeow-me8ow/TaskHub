using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<List<TaskEntity>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task UpdateTitleAsync(Guid id, string title)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.Title = title;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAllAsync()
        {
            _context.Tasks.RemoveRange(_context.Tasks);
            await _context.SaveChangesAsync();
        }
    }
}
