using LibraryApi.DTOs.Book;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public interface IBookService
    {
        Task<int> CreateBookAsync(BookCreateDto bookCreateDto);
        Task<IEnumerable<BookViewDto>> GetAllBooksAsync();
        Task<BookViewDto> GetBookByIdAsync(int id);
        Task UpdateBookAsync(BookUpdateDto dto);
        Task<BookDeleteDto> DeleteBookAsync(int id);
        Task<IEnumerable<BookViewDto>> GetBooksByAuthorNameAsync(string authorName);
        Task<IEnumerable<BookViewDto>> GetBooksByGenreNameAsync(string genreName);
        Task<IEnumerable<BookViewDto>> GetBooksByPriceRangeAsync(decimal Min, decimal Max);
    }
}
