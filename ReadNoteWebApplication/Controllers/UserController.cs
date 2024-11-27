using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using ReadNoteWebApplication.Data.Dtos.User;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromQuery] RegisterDto registerDto, CancellationToken cancellationToken = default)
        {
            await userService.RegisterAsync(registerDto.UserName, registerDto.PasswordHash, registerDto.Email,cancellationToken);

            return NoContent();
        }

        [Authorize]
        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] GetByEmailDto emailDto, CancellationToken cancellationToken = default)
        {
            User result = await userService.GetByEmailAsync(emailDto.Email,cancellationToken);

            return Ok(result);
        }

        //fix request
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginDto loginDto, CancellationToken cancellationToken = default)
        {
            await userService.LoginAsync(loginDto.Email, loginDto.Password,this.HttpContext,cancellationToken);

            return Ok();
        }
    }
}
