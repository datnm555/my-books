using my_books.Api.Data.Models;
using my_books.Api.Data.ViewModels;

namespace my_books.Api.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddPublisher(PublisherVm publisherVm)
        {
            var publisher = new Publisher
            {
                Name = publisherVm.Name,

            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetPublisherById(int id)
        {
            return _context.Publishers.FirstOrDefault(x => x.Id == id);
        }

        public Publisher UpdatePublisher(int id, PublisherVm publisherVm)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if (publisher == null)
            {
                return null;
            }
            publisher.Name = publisherVm.Name;

            _context.Publishers.Update(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if (publisher == null)
            {
                return;
            }
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
    }
}
