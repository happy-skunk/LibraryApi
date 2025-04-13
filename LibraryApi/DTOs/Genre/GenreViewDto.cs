namespace LibraryApi.DTOs.Genre
{
    public class GenreViewDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<String> Books { get; set; }
    }
}
