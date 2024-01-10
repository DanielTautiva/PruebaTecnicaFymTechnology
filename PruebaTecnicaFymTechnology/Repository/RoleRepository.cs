using PruebaTecnicaFymTechnology.Data;
using PruebaTecnicaFymTechnology.Models;
using PruebaTecnicaFymTechnology.Repository.IRepository;

namespace PruebaTecnicaFymTechnology.Repository
{
    public class RoleRepository : IRoleRepository
    {

        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateRoleUser(UserRole usersroles)
        {
            _db.UserRole.Add(usersroles);
            return Save();
        }

        public Role GetRol(string name)
        {
            return _db.Roles.First(x => x.Name.ToLower().Trim() == name);
        }

        public Role GetRol(int id)
        {
            return _db.Roles.First(c => c.Id == id);
        }

        public ICollection<Role> GetRols()
        {
            return _db.Roles.OrderBy(x => x.Name).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
