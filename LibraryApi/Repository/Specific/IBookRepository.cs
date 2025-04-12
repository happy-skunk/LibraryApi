using LibraryApi.Models;

namespace LibraryApi.Repository.Specific
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllIncludingAsync();
        Task<Book> GetByIdIncludingAsync(int id);
    }
}