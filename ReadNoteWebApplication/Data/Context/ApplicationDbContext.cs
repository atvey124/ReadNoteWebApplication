using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Context
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        
        [StackTraceHidden]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>(p => p.HasKey(x => new {x.UserId,x.NoteId}));
            modelBuilder.Entity<Portfolio>().HasOne(u => u.User).WithMany(p => p.Portfolios).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Portfolio>().HasOne(u => u.Note).WithMany(p => p.Portfolios).HasForeignKey(x => x.NoteId);

            modelBuilder.Entity<Note>().HasKey(x => x.Id);
            modelBuilder.Entity<Note>().Property(x => x.Text).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(200);
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
