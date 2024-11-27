using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReadNoteWebApplication.Data.Dtos.Note;
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
        [Authorize]
        [HttpPost("Creat")]
        public async Task<IActionResult> CreatAsync([FromQuery] CreatDto creatDto, CancellationToken cancellationToken = default)
        {
            await noteService.CreatAsync(creatDto.Text,creatDto.Title,cancellationToken);
            return NoContent();
        }

        [Authorize]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdDto getById, CancellationToken cancellationToken = default)
        {
            Note result = await noteService.GetByIdAsync(getById.Id,cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateDto updateDto, CancellationToken cancellationToken = default)
        {
            await noteService.UpdateAsync(updateDto.Id,updateDto.newText,updateDto.newTitle,cancellationToken);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteDto deleteDto, CancellationToken cancellationToken = default)
        {
            await noteService.DeleteAsync(deleteDto.Id,cancellationToken);

            return NoContent();
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            List<Note> listNote = await noteService.GetAllAsync(cancellationToken);

            return Ok(listNote);
        }

        [Authorize]
        [HttpGet("GetByTitle")]
        public async Task<IActionResult> GetAllByTitleAsync([FromQuery] GetByTitleDto getByTitle, CancellationToken cancellationToken = default)
        {
            List<Note> listNote = await noteService.GetAllByTitleAsync(getByTitle.Title,cancellationToken);

            return Ok(listNote);
        }

        [Authorize]
        [HttpPut("putLike")]
        public async Task<IActionResult> PutLikeNoteByIdAsync([FromQuery] PutLIkeDto putLike, CancellationToken cancellationToken = default)
        {
            await noteService.PutLikeNoteByIdAsync(putLike.Id, cancellationToken);

            return NoContent();
        }

        [Authorize]
        [HttpPut("putDislike")]
        public async Task<IActionResult> PutDislikeNoteByIdAsync([FromQuery] PutDislike putDislike, CancellationToken cancellationToken = default)
        {
            await noteService.PutDislikeNoteByIdAsync(putDislike.Id, cancellationToken);

            return NoContent();
        }
    }
}
