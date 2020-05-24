using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;

namespace EasyCatch.Infrastructure.Services
{
    public interface IProductService
    {
         Task<ProductResponse> AddProduct(ProductRequest product, HttpRequest request);
         Task<ProductResponse> DeleteProduct(string id);
         Task<ProductResponse> GetProductByID(string id);
         Task<ProductResponse> GetProductToBuyByID(string id);

         Task<List<ProductResponse>> GetProductsByName();
         Task<List<ProductToBuy>> GetAllProductsRelatedAsync();
         Task<List<Product>> GetAllProducts();
    }
}