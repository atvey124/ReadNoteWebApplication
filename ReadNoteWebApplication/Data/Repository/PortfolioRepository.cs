using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Repository
{
    public class PortfolioRepository(ApplicationDbContext context) : IPortfolioRepository
    {
        public async Task AddPortfolioAsync(Portfolio portfolio, CancellationToken cancellationToken = default)
        {
            await context.Portfolios.AddAsync(portfolio);
            await context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetPortfolioAsync(User? user, CancellationToken cancellationToken = default)
        {
            return await context.Portfolios.Where(u => u.UserId == user.Id).Select(note => new Note
            {
                Id = note.NoteId,
                Text = note.Note.Text,
                Title = note.Note.Title,
                Like = note.Note.Like,
                Dislike = note.Note.Dislike,
                Created = note.Note.Created,
                Updated = note.Note.Updated

            }).ToListAsync();
        }
    }
}
