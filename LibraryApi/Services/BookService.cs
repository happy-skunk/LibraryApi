using LibraryApi.Cashe;
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
        private readonly ICacheService _cache;

        public BookService(IBookRepository bookRepository, ICacheService cache)
        {
            _bookRepo = bookRepository;
            _cache = cache;
        }

        public async Task<int> CreateBookAsync(BookCreateDto bookCreateDto)
        {
            var book = bookCreateDto.ToBook();
            await _bookRepo.Add(book);

            _cache.Remove("books_all");
            return book.Id;
        }

        public async Task<IEnumerable<BookViewDto>> GetAllBooksAsync()
        {
            string cacheKey = "books_all";
            var cached = _cache.Get<IEnumerable<BookViewDto>>(cacheKey);
            if (cached != null) return cached;

            var books = await _bookRepo.GetAllIncludingAsync();
            var result = books.Select(BookMapper.ToBookViewDto).ToList();

            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task<BookViewDto> GetBookByIdAsync(int id)
        {
            string cacheKey = $"book_{id}";
            var cached = _cache.Get<BookViewDto>(cacheKey);
            if (cached != null) return cached;

            var book = await _bookRepo.GetByIdIncludingAsync(id);
            if (book == null) return null;

            var result = book.ToBookViewDto();
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task UpdateBookAsync(BookUpdateDto dto)
        {
            var book = await _bookRepo.GetById(dto.Id);
            if (book == null) return;

            book = dto.ToBook();
            await _bookRepo.Update(book);

            _cache.Remove($"book_{dto.Id}");
            _cache.Remove("books_all");
        }

        public async Task<BookDeleteDto> DeleteBookAsync(int id)
        {
            var book = await _bookRepo.GetById(id);
            if (book == null) return null;

            await _bookRepo.Delete(id);

            _cache.Remove($"book_{id}");
            _cache.Remove("books_all");

            return new BookDeleteDto
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public async Task<IEnumerable<BookViewDto>> GetBooksByAuthorNameAsync(string authorName)
        {
            string cacheKey = $"books_author_{authorName.ToLower()}";
            var cached = _cache.Get<IEnumerable<BookViewDto>>(cacheKey);
            if (cached != null) return cached;

            var books = await _bookRepo.GetBooksByAuthorNameAsync(authorName);
            if (books == null) return null;

            var result = books.Select(BookMapper.ToBookViewDto).ToList();
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task<IEnumerable<BookViewDto>> GetBooksByGenreNameAsync(string genreName)
        {
            string cacheKey = $"books_genre_{genreName.ToLower()}";
            var cached = _cache.Get<IEnumerable<BookViewDto>>(cacheKey);
            if (cached != null) return cached;

            var books = await _bookRepo.GetBooksByGenreNameAsync(genreName);
            if (books == null) return null;

            var result = books.Select(BookMapper.ToBookViewDto).ToList();
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task<IEnumerable<BookViewDto>> GetBooksByPriceRangeAsync(decimal min, decimal max)
        {
            string cacheKey = $"books_price_{min}_{max}";
            var cached = _cache.Get<IEnumerable<BookViewDto>>(cacheKey);
            if (cached != null) return cached;

            var books = await _bookRepo.GetBooksByPriceRangeAsync(min, max);
            if (books == null) return null;

            var result = books.Select(BookMapper.ToBookViewDto).ToList();
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }
    }

}
