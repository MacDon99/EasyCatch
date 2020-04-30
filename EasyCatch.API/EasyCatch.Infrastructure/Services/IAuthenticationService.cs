using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Core.Responses;

namespace EasyCatch.API.Infrastructure.Services
{
    public interface IAuthenticationService
    {
         Task<UserRegisterResponse> RegisterUser(UserRegisterRequest user);
         Task<UserLoginResponse> LoginUser(UserLoginRequest user);
         Task<User> Login();
    }
}