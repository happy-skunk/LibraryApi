using LibraryApi.Repository.Specific;
using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Repository.Specific
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
