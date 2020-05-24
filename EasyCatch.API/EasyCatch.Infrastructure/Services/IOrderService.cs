using System;
using System.Threading.Tasks;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync();
         Task<OrderResponse> GetOrderByIDAsync(string id);
         Task<OrderResponse> DeleteOrder(string id);
         Task<OrderResponse> AddProductToOrderAsync(string orderId, string productId);
         Task<OrderResponse> DeleteProductFromOrderAsync(string orderId, string productId);
         
         Task<OrderResponse> SetOrderAddress(AddressRequest address);
    }
}