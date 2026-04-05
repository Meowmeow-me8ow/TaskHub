using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
