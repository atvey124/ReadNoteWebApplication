using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using System.Diagnostics;

namespace ReadNoteWebApplication.Controllers
{
    
    [ApiController]
    [Route("Note")]
    public class NoteContoller(INoteService noteService) : ControllerBase
    {
        [StackTraceHidden]
        [HttpPost]
        public async Task<IActionResult> CreatAsync(string text)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await noteService.CreatAsync(text);
            return NoContent();
        }

        [StackTraceHidden]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Note result = await noteService.GetByIdAsync(id);

            return Ok(result);
        }

        [StackTraceHidden]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id,string newText)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await noteService.UpdateAsync(id,newText);
            return NoContent();
        }

        [StackTraceHidden]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await noteService.DeleteAsync(id);

            return NoContent();
        }
    }
}
