using API_Electronic.Models;
using API_Electronic.ViewModels;

namespace API_Electronic.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<int> Create(UserModel userModel);
        Task Update(int id, UserModel userModel);
        Task Delete(int id);
    }
}
