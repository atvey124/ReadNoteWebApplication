using Microsoft.AspNetCore.Identity;
using ReadNoteWebApplication.Data.Interfaces;
using System.Security.Cryptography;
using System.Text;


namespace ReadNoteWebApplication.Data.Hashing
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) => 
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);

    }
}
