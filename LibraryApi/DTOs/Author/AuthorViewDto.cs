namespace LibraryApi.DTOs.Author
{
    public class AuthorViewDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<String> Books { get; set; }
    }
}
