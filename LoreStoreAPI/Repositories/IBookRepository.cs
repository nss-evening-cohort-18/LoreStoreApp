using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();

    }
}