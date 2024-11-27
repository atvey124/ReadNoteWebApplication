using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.User
{
    public class GetByEmailDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
