using ReadNoteWebApplication.Data.Interfaces;

namespace ReadNoteWebApplication.Data.Helpers
{
    public class QueryObject : IQueryObject
    {
        public int currentPageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
