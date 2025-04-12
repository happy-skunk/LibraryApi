using LibraryApi.DTOs;

namespace LibraryApi.Services
{
    public interface IBookService
    {
        Task<int> CreateBookAsync(BookCreateDto bookCreateDto);
    }
}
