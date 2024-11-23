using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;

namespace ReadNoteWebApplication.Controllers
{
    [ApiController]
    [Route("Portfolio")]
    public class PortfolioController(IPortfolioService portfolioService,IUserService userService,INoteService noteService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserPortfolioAsync(string username)
        {
            User? user = await userService.GetByUsernameAsync(username);
            List<Note> listNote = await portfolioService.GetPortfolioAsync(user);

            return Ok(listNote);
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(string username,int id)
        {
            User? user = await userService.GetByUsernameAsync(username);
            Note? note = await noteService.GetByIdAsync(id);

            await portfolioService.AddPortfolioAsync(user, note);
            return NoContent();
        }
    }
}
