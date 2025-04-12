using LibraryApi.Models;
using LibraryApi.Repository;
using LibraryApi.Repository.Specific;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetBooks() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var Book = _repository.GetById(id);
            if (Book == null) return NotFound();
            return Ok(Book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book Book)
        {
            _repository.Add(Book);
            return CreatedAtAction(nameof(GetBook), new { id = Book.Id }, Book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book Book)
        {
            if (id != Book.Id) return BadRequest();
            _repository.Update(Book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
