using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Api.Data.Services;
using my_books.Api.Data.ViewModels;

namespace my_books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public ActionResult AddPublisher([FromBody] PublisherVm bookVm)
        {
            _publisherService.AddPublisher(bookVm);
            return Ok();
        }


        [HttpGet]
        public ActionResult GetPublishers()
        {
            var books = _publisherService.GetPublishers();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult GetPublisherById(int id)
        {
            var book = _publisherService.GetPublisherById(id);
            return Ok(book);
        }


        [HttpPut("{id}")]
        public ActionResult UpdatePublisherById(int id, PublisherVm bookVm)
        {
            var book = _publisherService.UpdatePublisher(id, bookVm);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePublisherById(int id)
        {
            _publisherService.DeletePublisher(id);
            return Ok();
        }
    }
}
