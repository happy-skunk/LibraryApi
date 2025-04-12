using LibraryApi.DTOs;
using LibraryApi.Models;
using LibraryApi.Repository;
using LibraryApi.Repository.Specific;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }


        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookCreateDto dto)
        {
            var id = await _bookService.CreateBookAsync(dto);
            return CreatedAtAction(nameof(GetBook), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _bookService.UpdateBookAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }

    }
}
