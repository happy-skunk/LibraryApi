namespace LibraryApi.DTOs.Book
{
    public class BookViewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public uint Price { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
    }
}
