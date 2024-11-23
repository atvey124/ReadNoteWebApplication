using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Controllers
{
    [ApiController]
    [Route("Portfolio")]
    public class PortfolioController(IPortfolioService portfolioService,IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserPortfolioAsync(string username)
        {
            User? user = await userService.GetByUsernameAsync(username);
            List<Note> listNote = await portfolioService.GetPortfolioAsync(user);

            return Ok(listNote);
        }
    }
}
