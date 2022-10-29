
using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        List<Book> GetBookById(int id);
        void AddBook(Book book);

        int DeleteBook(int id);

        int UpdateBook(int id, Book book);


    }
}