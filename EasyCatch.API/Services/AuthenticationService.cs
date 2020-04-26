using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Helpers;
using EasyCatch.API.Models;
using EasyCatch.API.Repositories;

namespace EasyCatch.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly Validations _validations;
        public AuthenticationService(IUserRepository userRepository, Validations validations )
        {
            _userRepository = userRepository;
            _validations = validations;
        }
        public Task<User> Login()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest user)
        {
            if(_validations.ValidateUser(user).Count != 0)
            {
                return new UserRegisterResponse() {
                    Success = false,
                    Token = null,
                    UserModel = new UserForResponse(){
                        Login = user.Login,
                        Email = user.Email,
                        FullName = string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Surname) ? user.Name + user.Surname : GetValidName(user.Name, user.Surname)
                    },
                    Errors = user.Errors
                };
            }

            var userToRegister = new User() {
                Login = user.Login,
                Password = !string.IsNullOrWhiteSpace(user.Password) ? Encoding.UTF8.GetBytes(user.Password) : null,
                Email = user.Email,
                FullName = GetValidName(user.Name, user.Surname)
            };

            return await _userRepository.RegisterUser(userToRegister);
        }
        
        private string GetValidName(string name, string surname)
        {
            return name[0].ToString().ToUpper() + name.Remove(0, 1) + " " + surname[0].ToString().ToUpper() + surname.Remove(0, 1);
        }
    }
}