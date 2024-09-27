using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface INoteService
    {
        Task CreatAsync(string text, CancellationToken cancellationToken = default);
        Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, string newText,CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
