using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<ProductResponse> AddProductAsync(Product product);
         Task<ProductResponse> DeleteProductByIDAsync(Guid id);
         Task<ProductResponse> GetProductByIDAsync(Guid id);
         Task<ProductResponse> GetProductToBuyByIdAsync(int id);
         Task <Guid> GetProductIdFromProductToBuyInfo(ProductResponse product);
         Task<Product> GetWholeProductByIdAsync(Guid id);
         Task<List<ProductToBuy>> GetAllProductsRelatedAsync();
         Task<List<Product>> GetAllProducts();
         Task<bool> TakeOneProduct(Guid productId);
         Task<List<ProductResponse>> GetProductsByNameAsync(string name);
         Task<bool> ProductExist(Guid id);
    }
}