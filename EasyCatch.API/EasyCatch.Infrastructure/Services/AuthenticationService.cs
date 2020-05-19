using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Validators;
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
        private readonly UserValidations _validations;        private readonly IConfiguration _configuration;
        public AuthenticationService(IUserRepository userRepository, UserValidations validations, IConfiguration configuration)
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
            if(user.Login == null || await _userRepository.UserExists(user.Login) || _validations.ValidateUserRegister(user).Count != 0)
            {
                user.Errors = new List<string>();
                if(user.Login != null && await _userRepository.UserExists(user.Login))
                    user.Errors.Add("User with that login already exist!");

                _validations.ValidateUserRegister(user);

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
                Password = !string.IsNullOrWhiteSpace(user.Password) ? GetPasswordHashSalt(Encoding.UTF8.GetBytes(user.Password)) : null,
                Email = user.Email,
                FullName = GetValidName(user.Name, user.Surname),
                Role = "User"
            };

            var userToPass = await _userRepository.RegisterUser(userToRegister);
            userToPass.Token = GetAccessToken(userToRegister);
            return userToPass;
        }

        public async Task<UserLoginResponse> LoginUser(UserLoginRequest user)
        {
            UserLoginResponse userFromDatabase = null;

            user.Errors = _validations.ValidateUserLogin(user);
            
            if( user.Errors.Count != 0)
            {
                return new UserLoginResponse(){
                    Success = false,
                    Errors = user.Errors
                };
            }
            if(! await _userRepository.UserExists(user.Login))
            {
                user.Errors.Add("User does not exist!");
                return new UserLoginResponse(){
                    Success = false,
                    Errors = user.Errors
                };
            }

            userFromDatabase = await _userRepository.LoginUser(new User(){
                Login = user.Login,
                Password = GetPasswordHashSalt(Encoding.UTF8.GetBytes(user.Password)),
            });

            if(userFromDatabase == null)
            {
                user.Errors.Add("Username and password does not match!");
                return new UserLoginResponse(){
                    Success = false,
                    Errors = user.Errors
                };
            }
           // var userRole = GetUserByLogin(user.Login).Result.Role;
            userFromDatabase.Token = GetAccessToken(await GetUserByLogin(user.Login));
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
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var newToken = new {newTokenn = tokenHandler.WriteToken(token)};

            return new {token = tokenHandler.WriteToken(token)}.token;
        }
        private byte[] GetPasswordHashSalt(byte[] password)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Salt").Value)))
            {
                return hmac.ComputeHash(password);
            };
        }

        public async Task<User> GetUserByLogin(string login)
        {
            if(login == null)
                return null;
            if(!await _userRepository.UserExists(login))
                return null;

            return await _userRepository.GetUserByUsername(login);
        }
    }
}