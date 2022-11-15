using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookData;
        public BookController(IBookRepository bookData)
        {
            _bookData = bookData;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<Book> bookList = _bookData.GetBooks();

            if (bookList.Count <= 0 || bookList == null)
            {
                return NotFound();
            }

            return Ok(bookList);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetIndividualBook(int id)
        {
            Book resultBook = _bookData.GetBookById(id).FirstOrDefault();

            if (resultBook == null)
            {
                return NotFound("Book could not be found");
            }
            return Ok(resultBook);

        }


        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            List<string> errors = Book.BookValidator(book);
            if(errors.Count > 0)
            {
                string errorString = "";
                foreach(string error in errors)
                {
                    errorString += error + "\n";
                }
                return BadRequest(errorString);
            } else
            {
                _bookData.AddBook(book);
                return Ok();
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult updateIndividualBook(int id, [FromBody] Book book)
        {
            int bookToUpdate = _bookData.UpdateBook(id, book);

            if (bookToUpdate <= 0)
            {
                return BadRequest("Book does not exist");
            }

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIndividualBook(int id)
        {
            int bookToDelete = _bookData.DeleteBook(id);
            if (bookToDelete <= 0)
            {
                return BadRequest("Book does not exist");
            }

            return Ok();

        }

        
    }
}