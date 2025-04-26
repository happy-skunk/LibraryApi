using LibraryApi.Models;

namespace LibraryApi.Repository.Specific
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllIncludingAsync();
        Task<Book> GetByIdIncludingAsync(int id);
        Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string authorName);
        Task<IEnumerable<Book>> GetBooksByGenreNameAsync(string genreName);
    }
}