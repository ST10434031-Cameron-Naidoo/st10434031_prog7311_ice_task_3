using Microsoft.EntityFrameworkCore;
using Primary_And_High_School.Domain;
using Primary_And_High_School.Services.Interfaces;
using Primary_High_School.DAL;

namespace Primary_And_High_School.Services.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Primary_And_HighDbContext _context;

        public BookRepository(Primary_And_HighDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Subject)
                .ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.Books
                .Include(b => b.Subject)
                .FirstOrDefault(b => b.BookId == id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}