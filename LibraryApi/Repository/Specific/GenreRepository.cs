using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Repository.Specific
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
