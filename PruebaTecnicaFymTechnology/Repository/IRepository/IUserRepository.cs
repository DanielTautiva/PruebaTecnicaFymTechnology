using PruebaTecnicaFymTechnology.Models;

namespace PruebaTecnicaFymTechnology.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(int id);

        User GetUser(string username);

        bool ExistUser(string username);

        bool ExistUser(int id);

        bool CreateUser(User user);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

        bool Save();

    }
}
