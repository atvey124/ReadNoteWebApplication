using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<Note>> GetPortfolioAsync(User? user,CancellationToken cancellationToken = default);

    }
}
