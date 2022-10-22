using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
