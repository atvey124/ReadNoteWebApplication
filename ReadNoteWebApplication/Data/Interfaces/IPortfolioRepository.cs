using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Note>> GetPortfolioAsync(User? user, CancellationToken cancellationToken = default);
    }
}
