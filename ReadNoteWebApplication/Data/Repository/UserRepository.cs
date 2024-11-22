using ReadNoteWebApplication.Data.Context;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        [StackTraceHidden]
        public async Task CreatAsync(User user, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
