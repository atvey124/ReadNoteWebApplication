using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<Note>> GetPortfolioAsync(User? user,CancellationToken cancellationToken = default);
        Task AddPortfolioAsync(User? user, Note? note, CancellationToken cancellationToken = default);

    }
}
