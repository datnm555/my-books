using my_books.Api.Data.Models;
using my_books.Api.Data.ViewModels;

namespace my_books.Api.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddAuthor(AuthorVm authorVm)
        {
            var author = new Author
            {
                Name = authorVm.Name,
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == id);
        }

        public Author UpdateAuthor(int id, AuthorVm authorVm)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return null;
            }
            author.Name = authorVm.Name;


            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return;
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
