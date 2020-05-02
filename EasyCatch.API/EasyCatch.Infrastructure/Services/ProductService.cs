using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;
using EasyCatch.Core.Responses;
using EasyCatch.Infrastructure.Repositories;
using EasyCatch.Infrastructure.Validators;

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
        public async Task<ProductResponse> AddProduct(ProductRequest product)
        {
            product.Errors = _validations.ValidateProduct(product);
            if(product.Errors.Count != 0)
            {
                return new ProductResponse()
                {
                    Success = false,
                    Message = "Failed to add a product",
                    Product = new ProductModel(){
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        PhotoUrl = product.PhotoUrl,
                        Quantity = product.Quantity
                    }
                };
            }
            return await _productRepository.AddProductAsync(new Product(){
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                PhotoUrl = product.PhotoUrl,
                Quantity = product.Quantity
            });
        }

        public async Task<ProductResponse> DeleteProduct(string id)
        {
            try
            {
                new Guid(id);
            }
            catch
            {
                return new ProductResponse(){
                    Success = false,
                    Message = "Product cannot be found"
                };
            }
            
            if(! await _productRepository.ProductExist(new Guid(id)))
                return new ProductResponse(){
                    Success = false,
                    Message = "Product cannot be found"
                };

            return await _productRepository.DeleteProductByIDAsync(new Guid(id));
        }

        public async Task<ProductResponse> GetProductByID(Guid id)
        {
            if(! await _productRepository.ProductExist(id))
                return new ProductResponse(){
                    Success = false,
                    Message = "Product cannot be found"
                };

            return await _productRepository.GetProductByIDAsync(id);
        }

        public Task<List<ProductResponse>> GetProductsByName()
        {
            throw new System.NotImplementedException();
        }
    }
}