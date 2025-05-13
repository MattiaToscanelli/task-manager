using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Service 
{
    public class TaskListService
    {
        private readonly TaskDbContext _db;

        public TaskListService(TaskDbContext db)
        {
            _db = db;
        }
 
        public async Task<List<TaskListM>> GetAllTaskListsAsync(int boardId)
        {
            return await _db.TaskLists
                .Include(tl => tl.Tasks)
                .Where(tl => tl.Board.Id == boardId)
                .ToListAsync();
        }


        public async Task<TaskListM> CreateTaskListAsync(TaskListM taskList)
        {
            taskList.Board = null; 
            _db.TaskLists.Add(taskList);
            await _db.SaveChangesAsync();
            return taskList;
        }

        public async Task<bool> DeleteTaskListAsync(int id)
        {
            var taskList = await _db.TaskLists
                .Include(tl => tl.Tasks)
                .FirstOrDefaultAsync(tl => tl.Id == id);

            if (taskList == null)
            {
                return false;
            }

            _db.TaskLists.Remove(taskList);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}