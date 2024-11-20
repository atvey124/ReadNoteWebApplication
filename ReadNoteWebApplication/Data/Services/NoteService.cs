using ReadNoteWebApplication.Data.Helpers;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ReadNoteWebApplication.Data.Repository
{

    internal class NoteService(INoteRepository noteRepository) : INoteService
    {
        [StackTraceHidden]
        public async Task CreatAsync(string text, string title, CancellationToken cancellationToken = default)
        {
            Note note = new Note()
            {
                Text = text,
                Title = title,
                Created = DateTime.UtcNow        
            };

            await noteRepository.CreatAsync(note, cancellationToken);
        }


        [StackTraceHidden]
        public async Task UpdateAsync(int id, string newText, string newTitle, CancellationToken cancellationToken = default)
        {
            Note? note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");

            note.Text = newText;
            note.Title = newTitle;
            note.Updated = DateTime.UtcNow;

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

        [StackTraceHidden]
        public async Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            QueryObject query = new QueryObject();

            List<Note> listNote = await noteRepository.GetAllAsync(cancellationToken);
            if (listNote.Count <= 0)
                throw new Exception("Notes not found");

            int skipNumber = (query.currentPageNumber - 1) * query.PageSize;
            return (listNote.Skip(skipNumber)).Take(query.PageSize).ToList();
        }

        [StackTraceHidden]
        public async Task<List<Note>> GetAllByTitleAsync(string title,CancellationToken cancellationToken = default)
        {
            QueryObject query = new QueryObject();

            List<Note> listNote = await noteRepository.GetAllByTitleAsync(title,cancellationToken);
            if (listNote.Count <= 0)
                throw new Exception("Notes not found");

            int skipNumber = (query.currentPageNumber - 1) * query.PageSize;
            return (listNote.Skip(skipNumber)).Take(query.PageSize).ToList();
        }

        [StackTraceHidden]
        public async Task PutLikeNoteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            Note? note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");
            else
                note.Like++;

            await noteRepository.UpdateAsync(note,cancellationToken);
        }

        [StackTraceHidden]
        public async Task PutDislikeNoteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            Note? note = await noteRepository.GetByIdAsync(id, cancellationToken);
            if (note == null)
                throw new Exception("Note not found");
            else
                note.Dislike++;

            await noteRepository.UpdateAsync(note, cancellationToken);
        }
    }
}