using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class CreateNoteDto
    {

        [Required]
        [MinLength(20, ErrorMessage = "Note text must contain 20 symbols minimum")]
        [MaxLength(300, ErrorMessage = "Note text must contain 300 symbols maximum")]
        public string Text { get; set; } = string.Empty;

        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;

    }
}
