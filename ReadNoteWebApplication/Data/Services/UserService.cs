using ReadNoteWebApplication.Data.Hashing;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Exceptions;

namespace ReadNoteWebApplication.Data.Services
{
    internal class UserService(IPasswordHasher passwordHasher,IUserRepository userRepository,IJwtProvider jwtProvider) : IUserService
    {
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            User? user = await userRepository.GetByEmailAsync(email, cancellationToken);
            if(user == null)
                throw new UserException("user not found");
            
            return user;
        }

        public async Task LoginAsync(string email, string password,HttpContext context,CancellationToken cancellationToken = default)
        {
            User? user = await userRepository.GetByEmailAsync(email,cancellationToken);
            if (user == null)
                throw new UserException("user not found");

            bool result = passwordHasher.Verify(password, user.PasswordHash);
            if (!result)
                throw new UserException("Failed to login");         
     
            string token = jwtProvider.GenerateToken(user);
            context.Response.Cookies.Append("test-cookie", token);

        }

        public async Task RegisterAsync(string username,string passwordHash,string email,CancellationToken cancellationToken = default)
        {
            string hashedPassword = passwordHasher.Generate(passwordHash);

            User user = new User
            {
                UserName = username,
                Email = email,
                PasswordHash = hashedPassword
            };

            await userRepository.RegisterAsync(user, cancellationToken);
        }
    }
}
