using System.ComponentModel.DataAnnotations;

namespace ReadNoteWebApplication.Data.Dtos.Note
{
    public class CreatDto
    {
        [Required]
        public string Title {  get; set; }

        [Required]  
        public string Text { get; set; }
    }
}
