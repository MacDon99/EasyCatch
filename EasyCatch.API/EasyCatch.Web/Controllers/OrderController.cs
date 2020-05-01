using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Helpers;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyCatch.API.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }
        [HttpPost("createorder")]
        public async Task<IActionResult> Add()
        {
            return StatusCode(200);
        }
        [HttpPost("addProduct/{orderId}/{productId}")]
        public async Task<IActionResult> Add(Guid orderId, Guid productId)
        {
            return StatusCode(200);
        }
    }
}