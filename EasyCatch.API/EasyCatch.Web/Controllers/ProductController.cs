using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Validators;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Add(int id)
        {
            return StatusCode(200);
        }
    }
}