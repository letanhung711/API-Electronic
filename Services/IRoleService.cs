using API_Electronic.Models;
using API_Electronic.ViewModels;

namespace API_Electronic.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRole();
        Task<Role> GetRoleById(int id);
        Task<int> Create(RoleModel roleModel);
        Task Update(int id, RoleModel roleModel);
        Task Delete(int id);
        Task DeleteUserFromRole(int id);

    }
}
