using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
