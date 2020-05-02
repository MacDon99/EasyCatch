using System.Threading.Tasks;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderResponse> CreateOrderAsync(OrderRequest order)
        {
            
            throw new System.NotImplementedException();
        }

        public OrderResponse DeleteOrder(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderResponse> GetOrderByIDAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public OrderResponse UpdateOrder(OrderRequest order)
        {
            throw new System.NotImplementedException();
        }
    }
}