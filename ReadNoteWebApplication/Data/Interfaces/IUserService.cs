using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(string username, string passwordHash, string email,CancellationToken cancellationToken = default);

        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task LoginAsync(string email,string password,HttpContext context,CancellationToken cancellationToken = default);    

    }
}
