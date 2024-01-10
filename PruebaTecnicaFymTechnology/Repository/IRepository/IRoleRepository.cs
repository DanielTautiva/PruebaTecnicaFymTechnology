using PruebaTecnicaFymTechnology.Models;

namespace PruebaTecnicaFymTechnology.Repository.IRepository
{
    public interface IRoleRepository
    {
        ICollection<Role> GetRols();

        Role GetRol(int id);

        Role GetRol(string name);

        bool CreateRoleUser(UserRole usersroles);
    }
}
