using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IUserService
    {
        Task CreatAsync(string username, string email,string password,string roles = "User",CancellationToken cancellationToken = default);
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
        Task<bool> SignInAsync(string username,string password,CancellationToken cancellationToken = default);
    }
}
