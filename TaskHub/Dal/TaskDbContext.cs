using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
