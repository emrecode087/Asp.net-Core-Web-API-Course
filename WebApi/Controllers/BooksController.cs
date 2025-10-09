using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
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
            try
            {
                var book = _manager.BookService.GetOneBookById(id, false);
                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book object cannot be null.");

            try
            {
                _manager.BookService.CreateOneBook(book);
                
                return Ok("Book created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book object cannot be null.");

            try
            {
                _manager.BookService.UpdateOneBook(id, book, true);

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            { 
                _manager.BookService.DeleteOneBook(id, false);
                

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
