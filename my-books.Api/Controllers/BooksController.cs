using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Api.Data.Services;
using my_books.Api.Data.ViewModels;

namespace my_books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] BookVm bookVm)
        {
            _bookService.AddBook(bookVm);
            return Ok();
        }


        [HttpGet]
        public ActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateBookById(int id, BookVm bookVm)
        {
            var book = _bookService.UpdateBook(id, bookVm);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBookById (int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
