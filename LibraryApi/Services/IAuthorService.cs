using LibraryApi.DTOs.Author;

namespace LibraryApi.Services
{
    public interface IAuthorService
    {
        Task<int> CreateAuthorAsync(AuthorCreateDto AuthorCreateDto);
        Task<IEnumerable<AuthorViewDto>> GetAllAuthorsAsync();
        Task<AuthorViewDto> GetAuthorByIdAsync(int id);
        Task UpdateAuthorAsync(AuthorUpdateDto dto);
        Task<AuthorDeleteDto> DeleteAuthorAsync(int id);
    }
}
