using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private IBookRepository _bookData;
        public BookController(IBookRepository bookData)
        {
            _bookData = bookData;
        }

        // GET: api/<BookController>
        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return _bookData.GetBooks();

        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book GetIndividualBook(int id)
        {
            return _bookData.GetBookById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
           _bookData.AddBook(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void DeleteIndividualBook(int id)
        {
            int bookToDelete = _bookData.DeleteBook(id);
        }

        
    }
}