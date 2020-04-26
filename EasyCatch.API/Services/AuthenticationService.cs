using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Models;
using EasyCatch.API.Repositories;

namespace EasyCatch.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User> Login()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRegisterResponse> RegisterUser(UserRegisterRequest user)
        {
            var userToRegister = new User() {
                Login = user.Login,
                Password = !string.IsNullOrWhiteSpace(user.Password) ? Encoding.UTF8.GetBytes(user.Password) : null,
                Email = user.Email,
                FullName = GetValidName(user.Name, user.Surname)
            };

            return _userRepository.RegisterUser(userToRegister);
        }
        
        private string GetValidName(string name, string surname)
        {
            return name[0].ToString().ToUpper() + name.Remove(0, 1) + " " + surname[0].ToString().ToUpper() + surname.Remove(0, 1);
        }
    }
}