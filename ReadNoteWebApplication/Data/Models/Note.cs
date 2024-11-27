using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Models
{

    [Table("Notes")]
    public class Note
    {
        public int Id { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public string Text { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;


    }
}
