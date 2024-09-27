using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Repository
{
    [StackTraceHidden]
    internal class NoteService(INoteRepository noteRepository) : INoteService
    {
        public async Task CreatAsync(string text, CancellationToken cancellationToken = default)
        {
            Note note = new Note()
            {
                Text = text,
            };

            await noteRepository.CreatAsync(note,cancellationToken);
        }

        public async Task<Note?> GetByIdAsync(int id,CancellationToken cancellationToken = default)
        {
            Note note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if(note == null)
                throw new Exception("Note not found");

            return note;
        }

        public async Task UpdateAsync(int id, string newText,CancellationToken cancellationToken = default)
        {
            Note note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");

            note.Text = newText;
            noteRepository.UpdateAsync(note,cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            Note note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");

            noteRepository.DeleteAsync(note,cancellationToken);
        }
    }
}
