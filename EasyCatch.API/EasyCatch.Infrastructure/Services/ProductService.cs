using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;
using EasyCatch.Infrastructure.Repositories;
using EasyCatch.Infrastructure.Validators;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;

namespace EasyCatch.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductValidations _validations;
        private readonly IProductRepository _productRepository;
        public ProductService(ProductValidations validations, IProductRepository productRepository)
        {
            _validations = validations;
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> AddProduct(ProductRequest product, HttpRequest request)
        {
            product.Errors = _validations.ValidateProduct(product);
            
            if(product.Errors.Count != 0 || GetImagePath(request, product) == null)
            {
                return new ProductResponse()
                {
                    Success = false,
                    Message = GetImagePath(request,product) == null ? "Failed to load file" : "Failed to add a product",
                    Product = new ProductModel(){
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        PhotoUrl = product.PhotoUrl,
                        Quantity = product.Quantity,
                        Errors = product.Errors
                    },
                };
            }
            return await _productRepository.AddProductAsync(new Product(){
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                PhotoUrl = GetImagePath(request, product),
                Quantity = product.Quantity
            });
        }

        public async Task<ProductResponse> DeleteProduct(string id)
        {
            if(! isValidId(id) || ! await _productRepository.ProductExist(new Guid(id)))
                return new ProductResponse(){
                    Success = false,
                    Message = "Product cannot be found"
                };

            return await _productRepository.DeleteProductByIDAsync(new Guid(id));
        }

        public async Task<ProductResponse> GetProductByID(string id)
        {
            if(! isValidId(id) || ! await _productRepository.ProductExist(new Guid(id)))
                return new ProductResponse(){
                    Success = false,
                    Message = "Product cannot be found"
                };

            return await _productRepository.GetProductByIDAsync(new Guid(id));
        }

        public Task<List<ProductResponse>> GetProductsByName()
        {
            throw new System.NotImplementedException();
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

        private string GetImagePath(HttpRequest request, ProductRequest product)
        {
            try
            {
                
                var file = request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images", $"{product.Name}");
                
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if(!Directory.Exists(pathToSave))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathToSave);
                }

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
        
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
        
                    return dbPath ;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ProductToBuy>> GetAllProductsRelatedAsync()
        {
            return await _productRepository.GetAllProductsRelatedAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
    }
}