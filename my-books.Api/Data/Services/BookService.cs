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
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
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
