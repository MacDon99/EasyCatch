using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Validators;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using EasyCatch.Infrastructure.Services;
using EasyCatch.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using System;

namespace EasyCatch.API.Web.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> AddProduct([FromForm]ProductRequest product)
        {
            var productToAdd = await _productService.AddProduct(product, this.Request);

            if(productToAdd.Success == false)
                return BadRequest(productToAdd);

            return StatusCode(201, productToAdd);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var productToGet = await _productService.GetProductByID(id);

            if(productToGet.Success == false)
                return BadRequest(productToGet);

            return Ok(productToGet);
        }
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var productToDelete = await _productService.DeleteProduct(id);

            if(productToDelete.Success == false)
                return BadRequest(productToDelete);

            return Ok(productToDelete);
        }
    }
}