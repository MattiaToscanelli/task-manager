using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Service
{
    public class TaskService
    {
        private readonly TaskDbContext _db;

        public TaskService(TaskDbContext db)
        {
            _db = db;
        }

        public async Task<List<TaskM>> GetAllTasksAsync(int taskListId)
        {
            return await _db.Tasks
                .Where(t => t.TaskList.Id == taskListId)
                .ToListAsync();
        }
        
        public async Task<TaskM> CreateTaskAsync(TaskM task)
        {
            task.TaskList = null; // Set TaskList to null to avoid circular reference
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _db.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return false;
            }

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<TaskM> UpdateTaskAsync(TaskM task)
        {
            var existingTask = await _db.Tasks
                .FirstOrDefaultAsync(t => t.Id == task.Id);

            if (existingTask == null)
            {
                return null;
            }

            existingTask.TaskListId = task.TaskListId;

            await _db.SaveChangesAsync();
            return existingTask;
        }
    }
}