using API_Electronic.Models;

namespace API_Electronic.Repositories
{
    public interface IRoleRepository
    {
        Task<int> Create(Role role);
        Task<Role?> GetById(int id);
        Task<Role?> GetByName(string name);
    }
}
