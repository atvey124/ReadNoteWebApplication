using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        [StackTraceHidden]
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        [StackTraceHidden]
        public async Task RegisterAsync(User user, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(user,cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
