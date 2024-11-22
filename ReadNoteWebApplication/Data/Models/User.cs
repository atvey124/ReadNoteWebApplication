using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }


        public string? Password { get; set; }

        public string? Roles { get; set; }  
    }
}
