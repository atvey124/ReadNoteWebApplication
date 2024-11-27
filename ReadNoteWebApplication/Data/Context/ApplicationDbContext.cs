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

        [StackTraceHidden]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasKey(x => x.Id);
            modelBuilder.Entity<Note>().Property(x => x.Text).HasMaxLength(200);


            base.OnModelCreating(modelBuilder);
        }
    }
}
