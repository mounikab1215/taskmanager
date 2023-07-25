using Microsoft.EntityFrameworkCore;
using TaskManage.Models;

namespace TaskManage.Data
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskTable> Tasks { get; set; }

    }
}
