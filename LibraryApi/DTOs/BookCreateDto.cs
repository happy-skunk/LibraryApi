namespace LibraryApi.DTOs
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
