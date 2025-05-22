using TaskManager.Models;

namespace TaskManager.Service
{
    public class TaskState
    {
        private TaskM? _task;
        public TaskM? Task => _task;

        public event Action? OnChange;

        public async Task LoadTaskAsync(TaskService service, int taskId)
        {
            if (taskId == 0)
            {
                _task = null;
                NotifyStateChanged();
                return;
            }
            _task = await service.GetTaskByIdAsync(taskId);
            NotifyStateChanged();
        }

        public void SetTask(TaskM task)
        {
            _task = task;
            NotifyStateChanged();
        }

        public void Clear()
        {
            _task = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
