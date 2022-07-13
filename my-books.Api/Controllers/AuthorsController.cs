using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Api.Data.Services;
using my_books.Api.Data.ViewModels;

namespace my_books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public ActionResult AddAuthor([FromBody] AuthorVm authorVm)
        {
            _authorService.AddAuthor(authorVm);
            return Ok();
        }


        [HttpGet]
        public ActionResult GetAuthors()
        {
            var books = _authorService.GetAuthors();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult GetAuthorById(int id)
        {
            var book = _authorService.GetAuthorById(id);
            return Ok(book);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateAuthorById(int id, AuthorVm authorVm)
        {
            var book = _authorService.UpdateAuthor(id, authorVm);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuthorById(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok();
        }
    }
}
