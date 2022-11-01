using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUserById(int id);

        User GetUserByFirebaseId(string firebaseUserId);

        public void AddUser(User user);

        public void DeleteUser(int id);

        public void UpdateUser(int id, User user);
    }
}
