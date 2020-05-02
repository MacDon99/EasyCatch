using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;

namespace EasyCatch.Infrastructure.Services
{
    public interface IProductService
    {
         Task<ProductResponse> AddProduct(ProductRequest product);
         Task<ProductResponse> DeleteProduct(string id);
         Task<ProductResponse> GetProductByID(Guid id);
         Task<List<ProductResponse>> GetProductsByName();
    }
}