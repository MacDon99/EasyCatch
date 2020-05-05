using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCatch.API.Core.Models;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace EasyCatch.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProductResponse> AddProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return new ProductResponse(){
                Success = true,
                Message = "The following product has been added",
                Product = new ProductModel(){
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    PhotoUrl = product.PhotoUrl,
                    Quantity = product.Quantity
                }
            };
        }

        public async Task<ProductResponse> DeleteProductByIDAsync(Guid id)
        {
            var productFromDatabase = await _appDbContext.Products.FindAsync(id);
            _appDbContext.Products.Remove(productFromDatabase);
            await _appDbContext.SaveChangesAsync();
            return new ProductResponse(){
                Success = true,
                Message = "You have deleted the following product",
                Product = new ProductModel(){
                    Name = productFromDatabase.Name,
                    Price = productFromDatabase.Price,
                    Description = productFromDatabase.Description,
                    PhotoUrl = productFromDatabase.PhotoUrl,
                    Quantity = productFromDatabase.Quantity
                }
            };
        }

        public async Task<ProductResponse> GetProductByIDAsync(Guid id)
        {
            var productFromDatabase = await _appDbContext.Products.FindAsync(id);
            return new ProductResponse(){
                Success = true,
                Message = "You get the following product",
                Product = new ProductModel(){
                    Name = productFromDatabase.Name,
                    Price = productFromDatabase.Price,
                    Description = productFromDatabase.Description,
                    PhotoUrl = productFromDatabase.PhotoUrl,
                    Quantity = productFromDatabase.Quantity
                }
            };
        }

        public Task<List<ProductResponse>> GetProductsByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetWholeProductByIdAsync(Guid id)
        {
            return await _appDbContext.Products.FindAsync(id);
        }

        public async Task<bool> ProductExist(Guid id)
        {
            return await _appDbContext.Products.FindAsync(id) != null;
        }

        public List<ProductToBuy> GetAllProducts()
        {
            return  _appDbContext.ProductToBuy.ToList();
        }

        public async Task<bool> TakeOneProduct(Guid productId)
        {
            _appDbContext.Products.FirstOrDefault(p => p.Id == productId).Quantity-=1;
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}