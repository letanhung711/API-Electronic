using API_Electronic.Models;
using API_Electronic.Repositories;
using API_Electronic.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_Electronic.Services
{
    public class UserService : IUserService
    {
        private readonly ElectronicDbContext _context;
        private readonly IUserRepository _userRepository;
        public UserService(ElectronicDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<int> Create(RegisterModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException("User model is null.");
            }

            var existingUserByUsername = await _userRepository.GetByUsername(userModel.UserName);
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists");
            }

            var existingUserByEmail = await _userRepository.GetByEmail(userModel.Email);
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("Email already exists");
            }

            var hashedPassword = "";
            if (!string.IsNullOrEmpty(userModel.Password))
            {
                hashedPassword = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            }
            var user = new User
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                Password = hashedPassword,
                BirthDate = userModel.BirthDate,
                Create_Time = userModel.Create_Time
            };
            return await _userRepository.Create(user);
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return user == null ? throw new ArgumentException("User not found.") : user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return user == null ? throw new ArgumentException("User not found.") : user;
        }

        public async Task Update(int id, UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException("User model is null.");
            }

            var getUser = await _userRepository.GetById(id);
            if (getUser == null)
            {
                throw new ArgumentException("User not found.");
            }

            if (!string.IsNullOrEmpty(userModel.Password))
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
                getUser.Password = hashedPassword;
            }

            getUser.UserName = userModel.UserName;
            getUser.Email = userModel.Email;
            getUser.FullName = userModel.FullName;
            getUser.PhoneNumber = userModel.PhoneNumber;
            getUser.BirthDate = userModel.BirthDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ArgumentException("An error occurred while updating user.", ex);
            }
        }
    }
}
