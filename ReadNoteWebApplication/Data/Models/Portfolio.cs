using System.ComponentModel.DataAnnotations.Schema;

namespace ReadNoteWebApplication.Data.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public int UserId { get; set; }  

        public int NoteId { get;set; }

        public User User { get; set; }

        public Note Note { get; set; }
    }
}
