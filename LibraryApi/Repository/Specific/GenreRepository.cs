using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Repository.Specific
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllIncludingAsync()
        {
            return await _context.Genres
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Genre> GetByIdIncludingAsync(int id)
        {
            return await _context.Genres
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
