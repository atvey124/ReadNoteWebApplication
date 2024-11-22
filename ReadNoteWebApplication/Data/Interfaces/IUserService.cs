namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IUserService
    {
        Task CreatAsync(string username, string email,string password,string roles = "User",CancellationToken cancellationToken = default);
    }
}
