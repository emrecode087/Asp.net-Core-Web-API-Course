using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        

        [HttpGet("GetAll")] 
        public IActionResult GetAll()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            
            if(book is null)
            {
                return NotFound(); // 404
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute(Name ="id")] int id, 
           [FromBody] Book book)
        {
            // check
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));
            if(entity is null)
            {
                return NotFound(); //404
            }

            //check id

            if (id != book.Id)
                return BadRequest();  //400

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if (book is null)
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"Book with id:{id} could not found."
                });
            ApplicationContext.Books.Remove(book);
            return NoContent();
        }

        // 204 No Content
        // 404 Not Found

        [HttpPatch("id")]
        public IActionResult PartialUpdateBook([FromRoute(Name = "id")] int id,[FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check entity
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if ( entity is null)
            {
                return NotFound(); //404
            }

            bookPatch.ApplyTo(entity);
            return NoContent();  // 204
        }
    }
}
