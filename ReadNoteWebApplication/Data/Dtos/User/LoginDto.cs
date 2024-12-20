﻿using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.User
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
