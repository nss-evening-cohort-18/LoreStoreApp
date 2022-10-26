using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void AddBook(Book book);

        int DeleteBook(int id);


    }
}