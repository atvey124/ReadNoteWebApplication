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


namespace ReadNoteWebApplication.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [StackTraceHidden]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(string username,string email,string password)
        {
            await userService.CreatAsync(username, email, password);
            
            return NoContent();
        }
    }
}
