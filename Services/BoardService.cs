using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Service 
{
    public class BoardService
    {
        private readonly TaskDbContext _db;

        public BoardService(TaskDbContext db)
        {
            _db = db;
        }

        public async Task<List<BoardM>> GetAllBoardsAsync()
        {
            return await _db.Boards
                .Include(b => b.taskLists)
                .ThenInclude(tl => tl.Tasks)
                .ToListAsync();
        }

        public async Task<BoardM?> GetBoardByIdAsync(int id)
        {
            return await _db.Boards
                .Include(b => b.taskLists)
                .ThenInclude(tl => tl.Tasks)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BoardM> CreateBoardAsync(BoardM board)
        {
            _db.Boards.Add(board);
            await _db.SaveChangesAsync();
            return board;
        }

        public async Task DeleteBoardAsync(int id)
        {
            var board = await _db.Boards.FindAsync(id);
            if (board != null)
            {
                _db.Boards.Remove(board);
                await _db.SaveChangesAsync();
            }
        }
    }
}