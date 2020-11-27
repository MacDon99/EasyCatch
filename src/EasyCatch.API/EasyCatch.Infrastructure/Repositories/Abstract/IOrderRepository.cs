using System;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
         Task<OrderResponse> CreateOrderAsync(Order order);
         Task<OrderResponse> GetOrderByIDAsync(Guid id);
         OrderResponse DeleteOrder(Order order);
         Task<bool> OrderExist(Guid orderId);
         Task<OrderResponse> AddProductToOrderAsync(Guid orderId, ProductToBuy product, Guid productId);
         Task<OrderResponse> DeleteProductFromOrderAsync(Guid orderId, ProductToBuy product, Guid productId);
         Task<OrderResponse> SetOrderAddress(Guid orderId, string street, string houseNumber, string postCode, string city);
         Task<Order> GetWholeOrder(Guid orderId);
    }
}