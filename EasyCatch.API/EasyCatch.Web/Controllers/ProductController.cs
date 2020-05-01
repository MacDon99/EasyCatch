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
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            return StatusCode(200);
        }
    }
}