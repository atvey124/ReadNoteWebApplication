using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Controllers
{
    [StackTraceHidden]
    [ApiController]
    [Route("Note")]
    public class NoteContoller(INoteService noteService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatAsync(string text)
        {
            await noteService.CreatAsync(text);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Note result = await noteService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id,string newText)
        {
            await noteService.UpdateAsync(id,newText);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await noteService.DeleteAsync(id);

            return NoContent();
        }
    }
}
