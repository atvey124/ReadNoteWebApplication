namespace ReadNoteWebApplication.Data.Interfaces
{
    public interface IQueryObject
    {
        public int currentPageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
