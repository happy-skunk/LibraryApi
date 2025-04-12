using LibraryApi.DTOs;

namespace LibraryApi.Services
{
    public interface IBookService
    {
        Task<int> CreateBookAsync(BookCreateDto bookCreateDto);
        Task<IEnumerable<BookViewDto>> GetAllBooksAsync();
        Task<BookViewDto> GetBookByIdAsync(int id);
        Task UpdateBookAsync(BookUpdateDto dto);
        Task<BookDeleteDto> DeleteBookAsync(int id);
    }
}
