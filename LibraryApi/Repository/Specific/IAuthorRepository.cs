using LibraryApi.Models;

namespace LibraryApi.Repository.Specific
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllIncludingAsync();
        Task<Author> GetByIdIncludingAsync(int id);
    }
}
