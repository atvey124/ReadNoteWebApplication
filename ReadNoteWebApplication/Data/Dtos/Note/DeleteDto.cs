using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class DeleteDto
    {
        [Required]
        public int Id { get; set; }
    }
}
