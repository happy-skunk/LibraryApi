using LibraryApi.DTOs.Genre;
using LibraryApi.Models;
using LibraryApi.Repository.Specific;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _GenreRepo;
        public GenreService(IGenreRepository GenreRepository)
        {
            _GenreRepo = GenreRepository;
        }

        public async Task<int> CreateGenreAsync(GenreCreateDto GenreCreateDto)
        {
            var Genre = new Genre
            {
                Name = GenreCreateDto.Name,
            };

            await _GenreRepo.Add(Genre);
            return Genre.Id;
        }

        public async Task<IEnumerable<GenreViewDto>> GetAllGenresAsync()
        {
            var Genre = await _GenreRepo.GetAllIncludingAsync();
            return Genre.Select(Genre => new GenreViewDto
            {
                Id = Genre.Id,
                Name = Genre.Name,
                Books = Genre.Books?.Select(b => b.Title).ToList()
            });

        }

        public async Task<GenreViewDto> GetGenreByIdAsync(int id)
        {
            var Genre = await _GenreRepo.GetByIdIncludingAsync(id);
            if (Genre == null) return null;

            return new GenreViewDto
            {
                Id = Genre.Id,
                Name = Genre.Name,
                Books = Genre.Books?.Select(b => b.Title).ToList()
            };
        }

        public async Task UpdateGenreAsync(GenreUpdateDto dto)
        {
            var Genre = await _GenreRepo.GetById(dto.Id);
            if (Genre == null) return;

            Genre.Name = dto.Name;
            Genre.Id = dto.Id;

            await _GenreRepo.Update(Genre);
        }

        public async Task<GenreDeleteDto> DeleteGenreAsync(int id)
        {
            var Genre = await _GenreRepo.GetById(id);
            if (Genre == null) return null;

            await _GenreRepo.Delete(id);

            return new GenreDeleteDto
            {
                Id = Genre.Id,
                Name = Genre.Name,
            };
        }
    }
}