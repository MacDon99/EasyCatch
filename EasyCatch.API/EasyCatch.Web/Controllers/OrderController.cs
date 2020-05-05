using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCatch.API.Infrastructure.Validators;
using EasyCatch.API.Core.Requests;
using EasyCatch.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using EasyCatch.Infrastructure.Services;
using EasyCatch.Core.Requests;
using Microsoft.AspNetCore.Authorization;

namespace EasyCatch.API.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")] 
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("createorder")]
        public async Task<IActionResult> CreateOrder(OrderRequest order)
        {
            return StatusCode(201, await _orderService.CreateOrderAsync(order));
        }
        [HttpPatch("addProduct")]
        public async Task<IActionResult> AddProductToOrder(AddProductToOrderRequest request)
        {
            var orderToAddProduct = await _orderService.AddProductToOrderAsync(request.orderId, request.productId);
            if(orderToAddProduct.Success == false)
                return BadRequest(orderToAddProduct);

            return Ok(orderToAddProduct);
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(string orderId)
        {
            var orderFromDb = await _orderService.GetOrderByIDAsync(orderId);

            if(orderFromDb.Success == false)
                return BadRequest(orderFromDb);

            return Ok(orderFromDb);
        }
        [HttpPatch("setaddress")]
        public async Task<IActionResult> SetOrderAddress(AddressRequest address)
        {
            var orderToSetAddress = await _orderService.SetOrderAddress(address);

            if(orderToSetAddress.Success == false)
                return BadRequest(orderToSetAddress);

            return Ok(orderToSetAddress);
        }
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            var orderToDelete = await _orderService.DeleteOrder(orderId);

            if(orderToDelete.Success == false)
                return BadRequest(orderToDelete);

            return Ok(orderToDelete);
        }
    }
}