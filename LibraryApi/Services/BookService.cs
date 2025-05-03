using LibraryApi.DTOs.Book;
using LibraryApi.Mapper;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

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
            var book = bookCreateDto.ToBook();

            await _bookRepo.Add(book);
            return book.Id;
        }
        public async Task<IEnumerable<BookViewDto>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllIncludingAsync();
            return books.Select(BookMapper.ToBookViewDto);
        }

        public async Task<BookViewDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdIncludingAsync(id);
            if (book == null) return null;

            return book.ToBookViewDto();
        }

        public async Task UpdateBookAsync(BookUpdateDto dto)
        {
            var book = await _bookRepo.GetById(dto.Id);
            if (book == null) return;

            book = dto.ToBook();

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

        public async Task<IEnumerable<BookViewDto>> GetBooksByAuthorNameAsync(string authorName) 
        {
            var books = await _bookRepo.GetBooksByAuthorNameAsync(authorName);
            if (books == null) return null;

            return books.Select(BookMapper.ToBookViewDto);
        }
        public async Task<IEnumerable<BookViewDto>> GetBooksByGenreNameAsync(string genreName)
        {
            var books = await _bookRepo.GetBooksByGenreNameAsync(genreName);
            if (books == null) return null;

            return books.Select(BookMapper.ToBookViewDto);
        }
        public async Task<IEnumerable<BookViewDto>> GetBooksByPriceRangeAsync(decimal Min, decimal Max)
        {
            var books = await _bookRepo.GetBooksByPriceRangeAsync(Min, Max);
            if (books == null) return null;

            return books.Select(BookMapper.ToBookViewDto);
        }
    }
}
