using API_Electronic.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Electronic.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ElectronicDbContext _context;
        public RoleRepository(ElectronicDbContext context) 
        {
            _context = context;
        }
        public async Task<int> Create(Role role)
        {
            _context.Set<Role>().Add(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }

        public async Task<Role?> GetById(int id)
        {
            return await _context.Set<Role>().FindAsync(id);
        }

        public async Task<Role?> GetByName(string name)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
