using System.Collections.Generic;
using System.Linq;
using EasyCatch.API.Core.Models;
using EasyCatch.Core.Models;

namespace EasyCatch.Web.Data
{
    public class Seed
    {
        private readonly AppDbContext _appDbContext;
        public Seed(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void SeedProducts()
        {
            if(!_appDbContext.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product(){Name = "Fishing Rod", Price = 125, Description = "Jaxon Genesis Pro Spinning", PhotoUrl =  ""},
                    new Product(){}
                };
                _appDbContext.Products.AddRange(products);
            }

        }

    }
}