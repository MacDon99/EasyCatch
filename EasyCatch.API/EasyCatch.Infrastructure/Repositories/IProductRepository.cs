using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<ProductResponse> AddProduct(Product product);
         Task<ProductResponse> DeleteProduct();
         Task<ProductResponse> GetProductByID(Guid id);
         Task<List<ProductResponse>> GetProductsByName(string name);
    }
}