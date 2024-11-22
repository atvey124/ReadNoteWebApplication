using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Validations;
using ReadNoteWebApplication.Data.Exceptions;
using System.Diagnostics;


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
                    Password = password,
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
    }
}
