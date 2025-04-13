namespace LibraryApi.DTOs.Book
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
