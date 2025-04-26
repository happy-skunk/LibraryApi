using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LibraryApi.Repository.Specific
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllIncludingAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();
        }

        public async Task<Book> GetByIdIncludingAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string authorName) 
        {
            return await _context.Books
                .Where(b => b.Author != null && b.Author.Name == authorName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByGenreNameAsync(string genreName)
        {
            return await _context.Books
                .Where(b => b.Genre != null && b.Genre.Name == genreName)
                .ToListAsync();
        }
    }
}
