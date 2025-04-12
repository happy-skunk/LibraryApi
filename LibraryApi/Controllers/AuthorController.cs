using LibraryApi.Models;
using LibraryApi.Repository;
using LibraryApi.Repository.Specific;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAuthors() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var Author = _repository.GetById(id);
            if (Author == null) return NotFound();
            return Ok(Author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author Author)
        {
            _repository.Add(Author);
            return CreatedAtAction(nameof(GetAuthor), new { id = Author.Id }, Author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author Author)
        {
            if (id != Author.Id) return BadRequest();
            _repository.Update(Author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
