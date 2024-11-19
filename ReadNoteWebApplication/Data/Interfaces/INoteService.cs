using ReadNoteWebApplication.Data.Helpers;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface INoteService
    {
        Task CreatAsync(string text, string title,CancellationToken cancellationToken = default);
        Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, string newText,string newTitle,CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<Note>> GetAllByTitleAsync(string title,CancellationToken cancellationToken = default);
        Task PutLikeNoteById(int id, CancellationToken cancellationToken = default);
        Task PutDislikeNoteById(int id, CancellationToken cancellationToken = default);
    }
}
