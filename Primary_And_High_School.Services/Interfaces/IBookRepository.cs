using Primary_And_High_School.Domain;

namespace Primary_And_High_School.Services.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book? GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}