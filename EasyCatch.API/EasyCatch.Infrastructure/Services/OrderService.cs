using System;
using System.Linq;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;
using EasyCatch.Infrastructure.Repositories;
using EasyCatch.Infrastructure.Validators;

namespace EasyCatch.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly OrderValidations _orderValidations;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, OrderValidations orderValidations )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderValidations = orderValidations;
        }
        public Task<OrderResponse> CreateOrderAsync(OrderRequest order)
        {
            Order orderToPass = new Order(){
            };
            return _orderRepository.CreateOrderAsync(orderToPass);
        }

        public async Task<OrderResponse> DeleteOrder(string orderId)
        {
            if(!isValidId(orderId))
            {
                return new OrderResponse(){
                    Success = false,
                    Message = "Invalid OrderId"
                };
            }
            if(!await _orderRepository.OrderExist(new Guid(orderId)))
                return new OrderResponse(){
                    Success = false,
                    Message = "Cannot find order with that id"
                };

            var order =  await _orderRepository.GetWholeOrder(new Guid(orderId));
            
            return _orderRepository.DeleteOrder(order);
        }

        public async Task<OrderResponse> GetOrderByIDAsync(string id)
        {
            if(!isValidId(id))
            {
                return new OrderResponse(){
                    Success = false,
                    Message = "Invalid OrderId"
                };
            }
            if(! await _orderRepository.OrderExist(new Guid(id)))
            {
                return new OrderResponse(){
                    Success = false,
                    Message = "Cannot find order with that Id"
                };
            }
            
            var orderToReturn = await _orderRepository.GetOrderByIDAsync(new Guid(id));
            orderToReturn.Order.Products = _productRepository.GetAllProducts().Where(p => p.OrderId == new Guid(id)).ToList();
            return orderToReturn;
        }

        public async Task<OrderResponse> AddProductToOrderAsync(string orderId, string productId)
        {
           if(!isValidId(orderId) || !isValidId(productId))
           {
               if(!isValidId(orderId))
                return new OrderResponse(){
                    Success = false,
                    Message = "Invalid OrderId"
                };
                return new OrderResponse(){
                    Success = false,
                    Message = "Invalid ProductId"
                };
           }
           if(!await _orderRepository.OrderExist(new Guid(orderId)))
           {
               return new OrderResponse(){
                   Success = false,
                   Message = "Cannot find order with that Id"
               };
           }
            var productx = await _productRepository.GetProductByIDAsync(new Guid(productId));

            return await _orderRepository.AddProductToOrderAsync(new Guid(orderId), new ProductToBuy(){
                Name = productx.Product.Name,
                Price = productx.Product.Price,
                Quantity = 1
            }, new Guid(productId));
        }
        public async Task<OrderResponse> SetOrderAddress(AddressRequest address)
        {
            if(!isValidId(address.OrderId))
                return new OrderResponse(){
                    Success = false,
                    Message = "Invalid OrderId"
                };
            if(!await _orderRepository.OrderExist(new Guid(address.OrderId)))
           {
               return new OrderResponse(){
                   Success = false,
                   Message = "Cannot find order with that Id"
               };
           }

            _orderValidations.ValidateOrderAddress(address);
            if(address.Errors.Count != 0)
            {
                return new OrderResponse(){
                    Success = false,
                    Message = "Failed to set the address because of the following errors",
                    Errors = address.Errors,
                };
            }
            return await _orderRepository.SetOrderAddress(new Guid(address.OrderId), address.Street, address.HouseNumber, address.PostCode, address.City);
        }

        private bool isValidId(string id)
        {
            try
            {
                new Guid(id);
            }
            catch
            {
                return false;
            }
            return true;
        }


    }
}