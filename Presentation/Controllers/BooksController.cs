using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {

            var book = _manager.BookService.GetOneBookById(id, false);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book object cannot be null.");

            _manager.BookService.CreateOneBook(book);
            return Ok("Book created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book object cannot be null.");
            _manager.BookService.UpdateOneBook(id, book, true);
            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }
    }
}