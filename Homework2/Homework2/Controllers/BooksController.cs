using Homework2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            try
            {
                var booksFromDb = StaticDb.Books;
                return Ok(booksFromDb);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("getbyindex")]
        public IActionResult GetByIndex([FromQuery] int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest($"Id cannot be{id}");
                }
                if (id > StaticDb.Books.Count)
                {
                    return NotFound("The book you are searching for doesn't exist");
                }

                var response = StaticDb.Books.Where(book => book.Id == id);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("authorandtitle")]
        public IActionResult GetByAuthorAndTitle([FromQuery] string? author,
                                                 [FromQuery] string? title)
        {
            try
            {
                if(string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title) )
                {
                    return BadRequest("something went wrong, please try agian.");
                }

                var response = StaticDb.Books.Where(book => book.Author.ToLower() == author 
                                                          || book.Title.ToLower() == title);
                return Ok(response);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        // app.UseCors(x => x
                   //.AllowAnyMethod()
                   //.AllowAnyHeader()
                   //.SetIsOriginAllowed(origin => true)); ADDED !!!
        [HttpPost("postBook")]
        public IActionResult AddNewBook([FromBody] Book book)
        {
            StaticDb.Books.Add(book);
            return StatusCode(StatusCodes.Status201Created, book);
        }
    }
}
