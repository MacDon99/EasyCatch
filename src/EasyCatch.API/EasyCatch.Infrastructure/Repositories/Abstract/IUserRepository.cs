using System;
using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Core.Responses;

namespace EasyCatch.API.Infrastructure.Repositories
{
    public interface IUserRepository
    {
         Task<bool> UserExists(string username);
         Task<User> GetUserByID(Guid id);
         Task<User> GetUserByLogin(string login);
         Task<User> GetUserByUsername(string username);
         Task<UserRegisterResponse> RegisterUser(User user);
         Task<UserLoginResponse> LoginUser(User request);

    }
}