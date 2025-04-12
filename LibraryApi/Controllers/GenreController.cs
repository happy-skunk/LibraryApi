using LibraryApi.Models;
using LibraryApi.Repository;
using LibraryApi.Repository.Specific;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repository;

        public GenreController(IGenreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetGenres() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            var Genre = _repository.GetById(id);
            if (Genre == null) return NotFound();
            return Ok(Genre);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre Genre)
        {
            _repository.Add(Genre);
            return CreatedAtAction(nameof(GetGenre), new { id = Genre.Id }, Genre);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] Genre Genre)
        {
            if (id != Genre.Id) return BadRequest();
            _repository.Update(Genre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
