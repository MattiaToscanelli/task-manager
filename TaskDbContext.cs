using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<BoardM> Boards { get; set; }

    public DbSet<TaskListM> TaskLists { get; set; }

    public DbSet<TaskM> Tasks { get; set; }

}