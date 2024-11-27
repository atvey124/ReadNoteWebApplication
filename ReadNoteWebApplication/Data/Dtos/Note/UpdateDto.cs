using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class UpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string newText { get; set; }

        [Required]
        public string newTitle { get; set; }
    }
}
