using LibraryApi.DTOs.Book;
using LibraryApi.Models;

namespace LibraryApi.Mapper
{
    public static class BookMapper
    {
        public static Book ToBook(this BookCreateDto dto) 
        {
            return new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId,
                Price = dto.Price,
            };
        }

        public static Book ToBook(this BookUpdateDto dtp)
        {
            return new Book
            {
                Id = dtp.Id,
                Title = dtp.Title,
                AuthorId = dtp.AuthorId,
                GenreId = dtp.GenreId,
                Price = dtp.Price,
            };
        }

        public static BookViewDto ToBookViewDto(this Book book) 
        {
            return new BookViewDto
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                AuthorName = book.Author?.Name,
                GenreName = book.Genre?.Name,
            };
        }
    }
}
