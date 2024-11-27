using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class GetByIdDto
    {
        [Required]
        public int Id { get; set; }
    }
}
