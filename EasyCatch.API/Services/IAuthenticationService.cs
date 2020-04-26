using System.Threading.Tasks;
using EasyCatch.API.Models;

namespace EasyCatch.API.Services
{
    public interface IAuthenticationService
    {
         Task<UserRegisterResponse> RegisterUser(UserRegisterRequest user);
         Task<User> Login();
    }
}