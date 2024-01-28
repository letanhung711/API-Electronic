using API_Electronic.Models;
using API_Electronic.Repositories;
using API_Electronic.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_Electronic.Services
{
    public class RoleService : IRoleService
    {
        private readonly ElectronicDbContext _context;
        private readonly IRoleRepository _roleRepository;

        public RoleService(ElectronicDbContext context, IRoleRepository roleRepository) 
        {
            _context = context;
            _roleRepository = roleRepository;
        }
        public async Task<int> Create(RoleModel roleModel)
        {
            if(roleModel == null)
            {
                throw new ArgumentException("Role model is null.");
            }

            var existingRoleByName = await _roleRepository.GetByName(roleModel.Name);
            if (existingRoleByName != null)
            {
                throw new ArgumentException("Name already exists");
            }

            var role = new Role
            {
                Name = roleModel.Name
            };
            return await _roleRepository.Create(role);
        }

        public async Task Delete(int id)
        {
            var role = await _roleRepository.GetById(id);
            if(role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Role not found.");
            }
        }

        public Task DeleteUserFromRole(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetAllRole()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await _roleRepository.GetById(id);
            return role == null ? throw new ArgumentException("Role not found.") : role;
        }

        public async Task Update(int id, RoleModel roleModel)
        {
            if (roleModel == null)
            {
                throw new ArgumentException("Role model is null.");
            }
            var getRole = await _roleRepository.GetById(id);
            if (getRole == null) {
                throw new ArgumentException("Role not found.");
            }

            if (!string.IsNullOrEmpty(roleModel.Name))
            {
                getRole.Name = roleModel.Name;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ArgumentException("An error occurred while updating role.", ex);
            }
        }
    }
}
