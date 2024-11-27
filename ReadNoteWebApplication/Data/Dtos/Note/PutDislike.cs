using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class PutDislike
    {
        [Required]
        public int Id { get; set; }
    }
}
