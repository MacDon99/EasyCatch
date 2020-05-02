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
            var userToRegister = await _authService.RegisterUser(user);
            if(userToRegister.Success == false)
                return BadRequest(userToRegister);

            return StatusCode(201, userToRegister);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest user)
        {
            var userToLogin = await _authService.LoginUser(user);

            if(userToLogin.Success == false)
                return BadRequest(userToLogin);

            return Ok(userToLogin);
        }
    }
}