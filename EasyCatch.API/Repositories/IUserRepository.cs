using System;
using System.Threading.Tasks;
using EasyCatch.API.Models;

namespace EasyCatch.API.Repositories
{
    public interface IUserRepository
    {
         Task<bool> UserExists(string username);
         Task<User> GetUserByID(Guid id);
         Task<User> GetUserByUsername(string username);
         Task<UserRegisterResponse> RegisterUser(User user);
         Task<UserLoginResponse> LoginUser(UserLoginRequest request);

    }
}