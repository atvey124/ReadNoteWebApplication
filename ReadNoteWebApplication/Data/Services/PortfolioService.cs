using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace ReadNoteWebApplication.Data.Services
{
    public class PortfolioService(IPortfolioRepository portfolioRepository) : IPortfolioService
    {
        public async Task AddPortfolioAsync(User? user, Note? note, CancellationToken cancellationToken = default)
        {
            List<Note> portfolio = await portfolioRepository.GetPortfolioAsync(user);

            if (portfolio.Any(p => p.Id == note.Id))
                throw new PortfolioException("You Already like this note");

            Portfolio portfolioModel = new Portfolio
            {
                UserId = user.Id,
                NoteId = note.Id,
            };

            await portfolioRepository.AddPortfolioAsync(portfolioModel, cancellationToken);
        }

        public async Task<List<Note>> GetPortfolioAsync(User? user, CancellationToken cancellationToken = default)
        {
            if(user == null)
                throw new UserException("User not found");

            return await portfolioRepository.GetPortfolioAsync(user, cancellationToken);
        }
    }
}
