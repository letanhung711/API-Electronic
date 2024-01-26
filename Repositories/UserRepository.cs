using API_Electronic.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Electronic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ElectronicDbContext _context;
        public UserRepository(ElectronicDbContext context) 
        {
            _context = context;
        }

        public async Task<int> Create(User user)
        {
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Set<User>().FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
