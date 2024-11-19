using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Helpers;
using ReadNoteWebApplication.Data.Interfaces;
using ReadNoteWebApplication.Data.Models;
using ReadNoteWebApplication.Data.Repository;
using System.Diagnostics;

namespace ReadNoteWebApplication.Controllers
{
    
    [ApiController]
    [Route("Note")]
    public class NoteContoller(INoteService noteService) : ControllerBase
    {
        //FIX ROUTING
        [StackTraceHidden]
        [HttpPost]
        public async Task<IActionResult> CreatAsync(string text,string title)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await noteService.CreatAsync(text,title);;
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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id,string newText,string newTitle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await noteService.UpdateAsync(id,newText,newTitle);
            return NoContent();
        }

        [StackTraceHidden]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await noteService.DeleteAsync(id);

            return NoContent();
        }

        //FIX ROUTING
        [StackTraceHidden]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Note> listNote = await noteService.GetAllAsync();

            return Ok(listNote);
        }

        //FIX ROUTING
        [StackTraceHidden]
        [HttpGet("{title}")]
        public async Task<IActionResult> GetAllByTitleAsync(string title)
        {
            List<Note> listNote = await noteService.GetAllByTitleAsync(title);

            return Ok(listNote);
        }

        //FIX ROUTING
        [StackTraceHidden]
        [HttpPut]
        public async Task<IActionResult> PutLikeNoteById(int id, CancellationToken cancellationToken = default)
        {
            await noteService.PutLikeNoteById(id, cancellationToken);

            return NoContent();
        }

        //FIX ROUTING
        [StackTraceHidden]
        [HttpPut("/")]
        public async Task<IActionResult> PutDislikeNoteById(int id, CancellationToken cancellationToken = default)
        {
            await noteService.PutDislikeNoteById(id, cancellationToken);

            return NoContent();
        }
    }
}
