using PruebaTecnicaFymTechnology.Data;
using PruebaTecnicaFymTechnology.Models;
using PruebaTecnicaFymTechnology.Repository.IRepository;

namespace PruebaTecnicaFymTechnology.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateUser(User user)
        {
            _db.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _db.Users.Remove(user);
            return Save();
        }

        public bool ExistUser(string username)
        {
            bool exist = _db.Users.Any(x => x.Username.ToLower().Trim() == username);
            return exist;
        }

        public bool ExistUser(int id)
        {
            bool exist = _db.Users.Any(x => x.Id == id);
            return exist;
        }

        public User GetUser(int id)
        {
            return _db.Users.First(c => c.Id == id);
        }

        public User GetUser(string username)
        {
            return _db.Users.First(c => c.Username == username);
        }

        public ICollection<User> GetUsers()
        {
            return _db.Users.OrderBy(x => x.Username).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _db.Users.Update(user);
            return Save();
        }
    }
}
