using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Service
{
    public class TaskPriorityService
    {
        private readonly TaskDbContext _db;

        public TaskPriorityService(TaskDbContext db)
        {
            _db = db;
        }

        public async Task<List<TaskPriority>> GetAllTaskPrioritiesAsync()
        {
            return await _db.TaskPriorities
                .ToListAsync();
        }

        public async Task<TaskPriority> CreateTaskPriorityAsync(TaskPriority taskPriority)
        {
            _db.TaskPriorities.Add(taskPriority);
            await _db.SaveChangesAsync();
            return taskPriority;
        }

        public async Task<bool> DeleteTaskPriorityAsync(int id)
        {
            var taskPriority = await _db.TaskPriorities
                .Include(tp => tp.Tasks)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (taskPriority == null)
            {
                return false;
            }

            _db.TaskPriorities.Remove(taskPriority);
            await _db.SaveChangesAsync();
            return true;
        }

        //update task priority
        public async Task<TaskPriority> UpdateTaskPriorityAsync(TaskPriority taskPriority)
        {
            var existingPriority = await _db.TaskPriorities
                .FirstOrDefaultAsync(tp => tp.Id == taskPriority.Id);

            if (existingPriority == null)
            {
                return null;
            }

            existingPriority.Name = taskPriority.Name;
            existingPriority.Order = taskPriority.Order;

            _db.TaskPriorities.Update(existingPriority);
            await _db.SaveChangesAsync();
            return existingPriority;
        }
    }
}