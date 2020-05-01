using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProductResponse> AddProduct(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            return new ProductResponse(){
                Success = true,
                Message = "The following product has been added",
                Product = new ProductRequest(){
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    PhotoUrl = product.PhotoUrl,
                    Quantity = product.Quantity
                }
            };
        }

        public Task<ProductResponse> DeleteProduct()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductResponse> GetProductByID(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductResponse>> GetProductsByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}