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
         OrderResponse UpdateOrder(Order order);
    }
}