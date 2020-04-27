using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Helpers;
using EasyCatch.API.Models;
using EasyCatch.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyCatch.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly Validations _validations;        private readonly IConfiguration _configuration;
        public AuthenticationService(IUserRepository userRepository, Validations validations, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _validations = validations;
            _configuration = configuration;
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

//  await _userRepository.RegisterUser(new User() {
            //     Login = user.Login,
            //     Password = !string.IsNullOrWhiteSpace(user.Password) ? Encoding.UTF8.GetBytes(user.Password) : null,
            //     Email = user.Email,
            //     FullName = GetValidName(user.Name, user.Surname)
            // });
            var userToPass = await _userRepository.RegisterUser(userToRegister);
            userToPass.Token = GetAccessToken(userToRegister);
            return userToPass;
            // return new UserRegisterResponse(){
            //     Success = true,
            //     Token = GetAccessToken(new User(){}),
            //     UserModel = new UserForResponse(){

            //     }
            // };
        }

        private string GetValidName(string name, string surname)
        {
            return name[0].ToString().ToUpper() + name.Remove(0, 1) + " " + surname[0].ToString().ToUpper() + surname.Remove(0, 1);
        }

        private string GetAccessToken(User user)
        {
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var newToken = new {newTokenn = tokenHandler.WriteToken(token)};

            return new {token = tokenHandler.WriteToken(token)}.token;
        }
    }
}