using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class GetByTitleDto
    {
        [Required]
        public string Title { get; set; }
    }
}
