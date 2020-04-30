using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Helpers;
using EasyCatch.API.Core.Models;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Core.Responses;
using EasyCatch.API.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyCatch.API.Infrastructure.Services
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
            if(_validations.ValidateUserRegister(user).Count != 0)
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

        public async Task<UserLoginResponse> LoginUser(UserLoginRequest user)
        {
            UserLoginResponse userFromDatabase = null;

            user.Errors = _validations.ValidateUserLogin(user);

            if( user.Errors.Count != 0)
            {
                return new UserLoginResponse(){
                    Errors = user.Errors
                };
            }
            if(! await _userRepository.UserExists(user.Login))
            {
                user.Errors.Add("User does not exist!");
                return new UserLoginResponse(){
                    Errors = user.Errors
                };
            }

            userFromDatabase = await _userRepository.LoginUser(user);

            if(userFromDatabase == null)
            {
                user.Errors.Add("Username and password does not match!");
                return new UserLoginResponse(){
                    Errors = user.Errors
                };
            }
            userFromDatabase.Token = GetAccessToken(new User(){
                Login = userFromDatabase.UserModel.Login,
            });
            return userFromDatabase;
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