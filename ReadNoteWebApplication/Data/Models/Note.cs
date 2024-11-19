using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ReadNoteWebApplication.Data.Models
{
    [StackTraceHidden]
    public class Note
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;

    }
}
