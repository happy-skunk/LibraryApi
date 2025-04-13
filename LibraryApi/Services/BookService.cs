using LibraryApi.DTOs.Book;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<BookViewDto>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllIncludingAsync();
            return books.Select(book => new BookViewDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author?.Name,
                GenreName = book.Genre?.Name
            });
        }

        public async Task<BookViewDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdIncludingAsync(id);
            if (book == null) return null;

            return new BookViewDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author?.Name,
                GenreName = book.Genre?.Name
            };
        }

        public async Task UpdateBookAsync(BookUpdateDto dto)
        {
            var book = await _bookRepo.GetById(dto.Id);
            if (book == null) return;

            book.Title = dto.Title;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;

            await _bookRepo.Update(book);
        }


        public async Task<BookDeleteDto> DeleteBookAsync(int id)
        {
            var book = await _bookRepo.GetById(id);
            if (book == null) return null;

            await _bookRepo.Delete(id);

            return new BookDeleteDto
            {
                Id = book.Id,
                Title = book.Title
            };
        }
    }
}
