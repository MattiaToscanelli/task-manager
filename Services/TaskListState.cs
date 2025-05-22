using TaskManager.Models;

namespace TaskManager.Service 
{
    public class TaskListState
    {
        private List<TaskListM> _taskLists = new();
        public IReadOnlyList<TaskListM> TaskLists => _taskLists.AsReadOnly();

        public event Action? OnChange;

        public async Task LoadBoardsAsync(TaskListService service, int boardId)
        {
            _taskLists = await service.GetAllTaskListsAsync(boardId);
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
