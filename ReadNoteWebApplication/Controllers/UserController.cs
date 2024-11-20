using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Helpers;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Repository;
using System.Diagnostics;
using ReadNoteWebApplication.Data.Context;
using Microsoft.EntityFrameworkCore;
using ReadNoteWebApplication.Data.Dtos.User;

namespace ReadNoteWebApplication.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager) 
        {
            _userManager = userManager;
        }   


        //fix this shit
        [StackTraceHidden]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(string Username,string Password,string Email)
        {
            User user = new User
            {
                UserName = Username,
                Email = Email,
            };

            var createdUser = await _userManager.CreateAsync(user, Password);

            if(createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if(roleResult.Succeeded)
                {
                    return Ok("user created succesfully");
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
            
        }
    }
}
