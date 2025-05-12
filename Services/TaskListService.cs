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
 
        public async Task<List<TaskList>> GetAllTaskListsAsync(int boardId)
        {
            return await _db.TaskLists
                .Include(tl => tl.Tasks)
                .Where(tl => tl.Board.Id == boardId)
                .ToListAsync();
        }


        public async Task<TaskList> CreateTaskListAsync(TaskList taskList)
        {
            _db.TaskLists.Add(taskList);
            await _db.SaveChangesAsync();
            return taskList;
        }

    }
}