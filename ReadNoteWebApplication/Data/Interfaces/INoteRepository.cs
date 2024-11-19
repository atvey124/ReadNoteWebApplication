using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Helpers;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface INoteRepository
    {
        Task CreatAsync(Note note,CancellationToken cancellationToken = default);
        Task<Note?> GetByIdAsync(int id,CancellationToken cancellationToken = default);
        Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
        Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
        Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<Note>> GetAllByTitleAsync(string title,CancellationToken cancellationToken = default);
    }
}
