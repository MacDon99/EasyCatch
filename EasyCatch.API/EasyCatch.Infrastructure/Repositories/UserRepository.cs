using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyCatch.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetUserByID(Guid id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Login == username);
        }

        public async Task<UserLoginResponse> LoginUser(User request)
        {
           var userFromDatabase = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Login == request.Login && u.Password == request.Password);
           if(userFromDatabase != null)
                return new UserLoginResponse(){
                    UserModel = new UserForResponse(){
                        Login = userFromDatabase.Login,
                        Email = userFromDatabase.Email,
                        FullName = userFromDatabase.FullName
                    }
                };
            return null;
        }

        public async Task<UserRegisterResponse> RegisterUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            
            return new UserRegisterResponse() {
                Success = true,
                Token = null,
                UserModel = new UserForResponse(){
                    Login = user.Login,
                    Email = user.Email,
                    FullName = user.FullName
                }
            };
        }

        public async Task<bool> UserExists(string username)
        {
            return await _appDbContext.Users.AnyAsync(x => x.Login.ToLower() == username.ToLower());
        }
    }
}