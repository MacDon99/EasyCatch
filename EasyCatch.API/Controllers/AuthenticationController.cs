using System.Linq;
using System.Threading.Tasks;
using EasyCatch.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyCatch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            return StatusCode(201);
        }
    }
}