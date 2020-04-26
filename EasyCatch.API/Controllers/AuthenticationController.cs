using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Helpers;
using EasyCatch.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyCatch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthenticationController : ControllerBase
    {
        private readonly UserRequestHelper _requestHelper;
        public AuthenticationController(UserRequestHelper helper )
        {
            _requestHelper = helper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            if(await _requestHelper.UserExists(user.Login))
            {
                return BadRequest("User with that username already exists!");
            }
            
            return StatusCode(201, new User(){
                Login = user.Login,
                Password = Encoding.UTF8.GetBytes(user.Password),
                Email = user.Email,
                FullName = user.Name + " " +  user.Surname
            });
        }
    }
}