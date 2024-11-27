using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class PutLIkeDto
    {
        [Required]
        public int Id { get; set; }
    }
}
