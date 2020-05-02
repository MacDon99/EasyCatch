using System;
using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.Core.Models;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<OrderResponse> CreateOrderAsync(Order order)
        {
            await _appDbContext.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
            return new OrderResponse(){
                Success = true,
                Message = "You have successfully created a new order.",
                Errors = null,
                Order = new OrderForResponse(){
                    Products = order.Products,
                    TotalPrice = order.TotalPrice,
                    Street = order.Street,
                    HouseNumber = order.HouseNumber,
                    PostCode = order.PostCode,
                    City = order.City
                }
            };
        }

        public OrderResponse DeleteOrder(Order order)
        {
            _appDbContext.Remove(order);

            return new OrderResponse(){
                Success = true,
                Message = "You have successfully deleted the following order.",
                Errors = null,
                Order = new OrderForResponse(){
                    Products = order.Products,
                    TotalPrice = order.TotalPrice,
                    Street = order.Street,
                    HouseNumber = order.HouseNumber,
                    PostCode = order.PostCode,
                    City = order.City
                }
            };
        }

        public async Task<OrderResponse> GetOrderByIDAsync(Guid id)
        {
            var orderFromDatabase = await _appDbContext.Orders.FindAsync(id);
            return new OrderResponse(){
                Success = true,
                Message = "You got the following order",
                Errors = null,
                Order = new OrderForResponse(){
                    Products = orderFromDatabase.Products,
                    TotalPrice = orderFromDatabase.TotalPrice,
                    Street = orderFromDatabase.Street,
                    HouseNumber = orderFromDatabase.HouseNumber,
                    PostCode = orderFromDatabase.PostCode,
                    City = orderFromDatabase.City 
                }
            };
        }

        public OrderResponse UpdateOrder(Order order)
        {
            var updatingOrder = _appDbContext.Update(order);
            return new OrderResponse(){
                Success = true,
                Message = "You updated the order with following data.",
                Errors = null,
                Order = new OrderForResponse(){
                    Products = order.Products,
                    TotalPrice = order.TotalPrice,
                    Street = order.Street,
                    HouseNumber = order.HouseNumber,
                    PostCode = order.PostCode,
                    City = order.City
                }
            };
        }
    }
}