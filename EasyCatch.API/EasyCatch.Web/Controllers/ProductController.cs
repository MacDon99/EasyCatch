using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Validators;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using EasyCatch.Infrastructure.Services;
using EasyCatch.Core.Requests;

namespace EasyCatch.API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductRequest product)
        {
            return StatusCode(200, await _productService.AddProduct(product));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {

            return StatusCode(200);
        }
    }
}