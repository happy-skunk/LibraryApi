using LibraryApi.DTOs.Author;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepo = authorRepository;
        }

        public async Task<int> CreateAuthorAsync(AuthorCreateDto AuthorCreateDto)
        {
            var author = new Author
            {
                Name = AuthorCreateDto.Name,
            };

            await _authorRepo.Add(author);
            return author.Id;
        }

        public async Task<IEnumerable<AuthorViewDto>> GetAllAuthorsAsync()
        {
            var author = await _authorRepo.GetAllIncludingAsync();
            return author.Select(author => new AuthorViewDto
            {
                Id = author.Id,
                Name = author.Name,
                Books = author.Books?.Select(b => b.Title).ToList()
            });

        }

        public async Task<AuthorViewDto> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepo.GetByIdIncludingAsync(id);
            if (author == null) return null;

            return new AuthorViewDto
            {
                Id = author.Id,
                Name = author.Name,
                Books = author.Books?.Select(b => b.Title).ToList()
            };
        }

        public async Task UpdateAuthorAsync(AuthorUpdateDto dto) 
        {
            var author = await _authorRepo.GetById(dto.Id);
            if (author == null) return;

            author.Name = dto.Name;
            author.Id = dto.Id;

            await _authorRepo.Update(author);
        }

        public async Task<AuthorDeleteDto> DeleteAuthorAsync(int id)
        {
            var author = await _authorRepo.GetById(id);
            if (author == null) return null;

            await _authorRepo.Delete(id);

            return new AuthorDeleteDto
            {
                Id = author.Id,
                Name = author.Name,
            };
        }
    }
}