using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadNoteWebApplication.Data.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Roles { get; set; }  

        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
