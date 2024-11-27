using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadNoteWebApplication.Data.Models
{
    [Table("Users")]
    public class User
    {
        public int Id {  get; set; }

        public string UserName {  get; set; }

        public string PasswordHash { get; set; }

        public string Email {  get; set; }


    }
}
