using Microsoft.AspNetCore.Mvc;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;

namespace Primary_And_High_School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookRepo.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookRepo.AddBook(book);
            return CreatedAtAction(nameof(GetById),
                new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.BookId) return BadRequest();
            _bookRepo.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book == null) return NotFound();
            _bookRepo.DeleteBook(id);
            return NoContent();
        }
    }
}