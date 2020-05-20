using System;
using System.Linq;
using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;
using Microsoft.EntityFrameworkCore;

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
                    Id = order.Id,
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
            _appDbContext.SaveChanges();

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
                    Id = orderFromDatabase.Id,
                    Products = orderFromDatabase.Products,
                    TotalPrice = orderFromDatabase.TotalPrice,
                    Street = orderFromDatabase.Street,
                    HouseNumber = orderFromDatabase.HouseNumber,
                    PostCode = orderFromDatabase.PostCode,
                    City = orderFromDatabase.City 
                }
            };
        }

        public async Task<OrderResponse> AddProductToOrderAsync(Guid orderId, ProductToBuy product, Guid productId)
        {

             var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            
            order.Products = _appDbContext.ProductToBuy.Where(p => p.OrderId == orderId).ToList();

             if(order.Products.Any(p => p.Description == product.Description))
             {
                order.Products.FirstOrDefault(p => p.Description == product.Description).Quantity +=1;
             }
             else
             {
                order.Products.Add(product);
             }
            order.TotalPrice += product.Price*product.Quantity;
            _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId).Result.Quantity-=1;

            await _appDbContext.SaveChangesAsync();
            return new OrderResponse(){
                Success = true,
                Message = "You updated the order with following data.",
                Errors = null,
                Order = new OrderForResponse(){
                    Id = order.Id,
                    Products = order.Products,
                    TotalPrice = order.TotalPrice,
                    Street = order.Street,
                    HouseNumber = order.HouseNumber,
                    PostCode = order.PostCode,
                    City = order.City
                }
            };
        }

        public async Task<Order> GetWholeOrder(Guid orderId)
        {
            return await _appDbContext.Orders.FindAsync(orderId);
        }

        public async Task<OrderResponse> SetOrderAddress(Guid orderId, string street, string houseNumber, string postCode, string city)
        {
            var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            order.Street = street;
            order.HouseNumber = houseNumber;
            order.PostCode = postCode;
            order.City = city;
            await _appDbContext.SaveChangesAsync();

            return new OrderResponse(){
                Success = true,
                Message = "You have set the order Address to the following address",
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

        public Task<bool> OrderExist(Guid orderId)
        {
            return _appDbContext.Orders.AnyAsync(o => o.Id == orderId);
        }
    }
}