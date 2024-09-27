using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface INoteRepository
    {
        Task CreatAsync(Note note,CancellationToken cancellationToken = default);
        Task<Note?> GetByIdAsync(int id,CancellationToken cancellationToken = default);
        Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
        Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
    }
}
