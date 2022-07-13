using Microsoft.EntityFrameworkCore;
using my_books.Api.Data.Models;
using my_books.Api.Data.ViewModels;

namespace my_books.Api.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;

        public BookService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddBook(BookVm bookVm)
        {
            var book = new Book
            {
                Author = bookVm.Author,
                CoverUrl = bookVm.CoverUrl,
                DateAdded = bookVm.DateAdded,
                DateRead = bookVm.DateRead,
                Description = bookVm.Description,
                Genre = bookVm.Genre,
                IsRead = bookVm.IsRead,
                Rate = bookVm.Rate,
                Title = bookVm.Title,
                PublisherId = bookVm.PublisherId
            };

            foreach (var authorId in bookVm.AuthorIds)
            {
                var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
                if (author != null)
                {
                    book.Authors.Add(author);
                }
            }

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public BookAuthorVm GetBookById(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).Include(x => x.Publisher).Include(x => x.Authors).FirstOrDefault();
            if (book == null)
            {
                return null;
            }
            return new BookAuthorVm
            {
                CoverUrl = book.CoverUrl,
                AuthorNames = book.Authors.Select(x => x.Name).ToList(),
                DateAdded = book.DateAdded,
                DateRead = book.DateRead,
                IsRead = book.IsRead,
                Description = book.Description,
                PublisherName = book.Publisher.Name,
                Id = book.Id,
                Rate = book.Rate,
                Title = book.Title,
                Genre = book.Genre,
            };
        }

        public Book UpdateBook(int id, BookVm bookVm)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return null;
            }
            book.DateAdded = bookVm.DateAdded;
            book.Author = bookVm.Author;
            book.CoverUrl = bookVm.CoverUrl;
            book.DateAdded = bookVm.DateAdded;
            book.DateRead = bookVm.DateRead;
            book.Description = bookVm.Description;
            book.Genre = bookVm.Genre;
            book.IsRead = bookVm.IsRead;
            book.Rate = bookVm.Rate;
            book.Title = bookVm.Title;

            _context.Update(book);
            _context.SaveChanges();
            return book;
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
