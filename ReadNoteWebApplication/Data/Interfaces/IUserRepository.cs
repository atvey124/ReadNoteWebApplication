using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IUserRepository
    {
        Task CreatAsync(User user, CancellationToken cancellationToken = default);
    }
}
