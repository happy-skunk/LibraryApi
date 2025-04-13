using LibraryApi.Models;
using LibraryApi.DTOs.Author;
using LibraryApi.Repository;
using LibraryApi.Repository.Specific;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _AuthorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAuthor(int id) 
        {
            var author = await _AuthorService.GetAuthorByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorCreateDto dto)
        {
            var id = await _AuthorService.CreateAuthorAsync(dto);
            return CreatedAtAction(nameof(GetAuthor), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _AuthorService.UpdateAuthorAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var deleted = await _AuthorService.DeleteAuthorAsync(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
