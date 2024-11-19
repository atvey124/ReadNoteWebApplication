using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ReadNoteWebApplication.Data.Repository
{

    internal class NoteService(INoteRepository noteRepository) : INoteService
    {
        [StackTraceHidden]
        public async Task CreatAsync(string text, CancellationToken cancellationToken = default)
        {
            Note note = new Note()
            {
                Text = text,
            };

            await noteRepository.CreatAsync(note, cancellationToken);
        }


        [StackTraceHidden]
        public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
        {
            Note? note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");

            note.Text = newText;
            await noteRepository.UpdateAsync(note, cancellationToken);
        }


        [StackTraceHidden]
        public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            Note? note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");

            return note;
        }


        [StackTraceHidden]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            Note? note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");

            await noteRepository.DeleteAsync(note, cancellationToken);
        }
    }
}