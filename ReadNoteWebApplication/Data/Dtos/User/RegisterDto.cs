using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
