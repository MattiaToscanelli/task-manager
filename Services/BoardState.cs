using TaskManager.Models;

namespace TaskManager.Service 
{
    public class BoardState
    {
        private List<BoardM> _boards = new();
        public IReadOnlyList<BoardM> Boards => _boards.AsReadOnly();

        public event Action? OnChange;

        public async Task LoadBoardsAsync(BoardService service)
        {
            _boards = await service.GetAllBoardsAsync();
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
