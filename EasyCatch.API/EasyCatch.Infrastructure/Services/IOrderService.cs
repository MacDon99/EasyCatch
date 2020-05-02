using System.Threading.Tasks;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(OrderRequest order);
         Task<OrderResponse> GetOrderByIDAsync(string id);
         OrderResponse DeleteOrder(string id);
         OrderResponse UpdateOrder(OrderRequest order);
    }
}