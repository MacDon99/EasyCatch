using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyCatch.API.Infrastructure.Helpers
{
    public class UserRequestHelper
    {       
        private readonly IUserRepository _userRepository;
        public UserRequestHelper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> UserExists(string username)
        {
            return await _userRepository.UserExists(username);
        }
    }
}