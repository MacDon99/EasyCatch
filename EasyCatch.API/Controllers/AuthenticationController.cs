using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Helpers;
using EasyCatch.API.Models;
using EasyCatch.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyCatch.API.Controllers
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
    }
}