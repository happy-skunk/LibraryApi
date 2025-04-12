using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Repository.Specific
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) 
        {

        }
    }
}