using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Validators;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using EasyCatch.API.Infrastructure.Repositories;

namespace EasyCatch.API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IUserRepository _userRepository;
        public AuthenticationController(IAuthenticationService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            if(user.Login != null && await _userRepository.UserExists(user.Login))
            {
                return BadRequest("User with that username already exists!");
            }

            return StatusCode(201, await _authService.RegisterUser(user));            
            // return StatusCode(201, new User(){
            //     Login = user.Login,
            //     Password = Encoding.UTF8.GetBytes(user.Password),
            //     Email = user.Email,
            //     FullName = user.Name + " " +  user.Surname
            // });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest user)
        {
            // if(user.Login != null && ! await _requestHelper.UserExists(user.Login))
            // {
            //     return BadRequest("User with that username does not exists!");
            // }

            return StatusCode(201, await _authService.LoginUser(user));            
            // return StatusCode(201, new User(){
            //     Login = user.Login,
            //     Password = Encoding.UTF8.GetBytes(user.Password),
            //     Email = user.Email,
            //     FullName = user.Name + " " +  user.Surname
            // });
        }
    }
}