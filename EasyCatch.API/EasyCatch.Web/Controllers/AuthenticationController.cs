using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Helpers;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyCatch.API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthenticationController : ControllerBase
    {
        private readonly UserRequestHelper _requestHelper;
        private readonly IAuthenticationService _authService;
        public AuthenticationController(UserRequestHelper helper, IAuthenticationService authService  )
        {
            _requestHelper = helper;
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            if(user.Login != null && await _requestHelper.UserExists(user.Login))
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