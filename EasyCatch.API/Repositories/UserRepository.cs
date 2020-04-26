using System.Threading.Tasks;
using EasyCatch.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyCatch.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _appDbContext.Users.AnyAsync(x => x.Login.ToLower() == username.ToLower());
        }
    }
}