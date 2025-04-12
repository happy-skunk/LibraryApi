using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;

namespace LibraryApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public async Task<int> CreateBookAsync(BookCreateDto bookCreateDto)
        {
            var book = new Book
            {
                Title = bookCreateDto.Title,
                AuthorId = bookCreateDto.AuthorId,
                GenreId = bookCreateDto.GenreId,
            };

            await _bookRepo.Add(book);
            return book.Id;
        }
    }
}
