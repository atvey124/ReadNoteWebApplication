using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user,CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email,CancellationToken cancellationToken = default);

    }
}
