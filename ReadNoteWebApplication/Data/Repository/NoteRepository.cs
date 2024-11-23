using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Helpers;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Repository
{
    
    internal class NoteRepository(ApplicationDbContext context) : INoteRepository
    {
        [StackTraceHidden]
        public async Task CreatAsync(Note note, CancellationToken cancellationToken = default)
        {
            await context.Notes.AddAsync(note,cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        [StackTraceHidden]
        public async Task<Note?> GetByIdAsync(int id,CancellationToken cancellationToken = default)
        {
            return await context.Notes.FirstOrDefaultAsync(n => n.Id == id);
        }

        [StackTraceHidden]
        public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
        {
            context.Notes.Update(note);
            await context.SaveChangesAsync(cancellationToken);
        }

        [StackTraceHidden]
        public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
        {
            context.Notes.Remove(note);
            await context.SaveChangesAsync(cancellationToken);
        }

        [StackTraceHidden]
        public async Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Notes.ToListAsync();
        }

        [StackTraceHidden]
        public async Task<List<Note>> GetAllByTitleAsync(string title,CancellationToken cancellationToken = default)
        {
           return await context.Notes.Where(n => n.Title.Contains(title)).ToListAsync();
        }

    }
}
