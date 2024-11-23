using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Validations;
using ReadNoteWebApplication.Data.Exceptions;
using System.Diagnostics;
using ReadNoteWebApplication.Data.Hashing;


namespace ReadNoteWebApplication.Data.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        [StackTraceHidden]
        public async Task CreatAsync(string username, string email, string password,string roles = "User",CancellationToken cancellationToken = default)
        {
            UserValidation userValidation = new UserValidation();
            (bool, string) userValidationRegister = userValidation.RegisterValidation(email, password, username);


            if (userValidationRegister.Item1)
            {
                User user = new User()
                {
                    Username = username,
                    Password = HashSHA128.HashSha128(password),
                    Roles = roles,
                    Email = email
                };

                await userRepository.CreatAsync(user,cancellationToken);
            }

            else
            {
                throw new UserException(userValidationRegister.Item2);
            }


        }

        [StackTraceHidden]
        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            User? user = await userRepository.GetByUsernameAsync(username,cancellationToken);
            if(user == null)
                throw new UserException($"{username} was not found.");

            return user;
        }

        //fix this
        [StackTraceHidden]
        public async Task<bool> SignInAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            User? user = await GetByUsernameAsync(username);

            if(user?.Password == HashSHA128.HashSha128(password))
            {
                return true;
            }
            else
            {
                throw new UserException($"password is not correct");
            }

        }

    }
}
