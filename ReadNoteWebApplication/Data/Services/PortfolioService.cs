using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace ReadNoteWebApplication.Data.Services
{
    public class PortfolioService(IPortfolioRepository portfolioRepository) : IPortfolioService
    {
        public async Task<List<Note>> GetPortfolioAsync(User? user, CancellationToken cancellationToken = default)
        {
            return await portfolioRepository.GetPortfolioAsync(user, cancellationToken);
        }
    }
}
