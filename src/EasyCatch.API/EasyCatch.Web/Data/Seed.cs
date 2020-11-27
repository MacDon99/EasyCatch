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
                    new Product(){Name = "Fishing Rod", Price = 125, Description = "Jaxon Genesis Pro Spinning", PhotoUrl =  "https://topfish.pl/pol_pl_Jaxon-Wedka-Genesis-Pro-Sea-Trout-Spin-3-00m-10-45g-100039640_2.jpg"},
                    new Product(){Name = "Fishing Rod", Price = 180, Description = "Germina spin 8-40", PhotoUrl = "https://narzedziagdansk.pl/userdata/public/gfx/10772/44aa9081446ab1338ae419a2fa0f.jpg"},
                    new Product(){Name = "Fly", Price = 1, Description = "Trout fly", PhotoUrl = "https://www.flytyer.com/wp-content/uploads/2017/08/FTOpener.jpg"},
                    new Product(){Name = "Gum", Price = 8.9M, Description = "Cannibal firetiger", PhotoUrl = "https://sklepdrapieznik.pl/sklep/39644-large_default/cannibal-10cm-firetiger.jpg"},
                    new Product(){Name = "Gum", Price = 12.5M, Description = "Herring Shad Pike", PhotoUrl = "https://static1.redpike.pl/pol_pl_Savage-Gear-4D-Herring-Shad-11cm-Pike-6865_1.jpg"},
                    new Product(){Name = "Reel", Price = 230, Description = "Daiwa Ninja", PhotoUrl = "https://rybomania24.pl/environment/cache/images/500_500_productGfx_13778/Daiwa_18_Ninja_LT_Reel_Main.jpg"},
                };
                _appDbContext.Products.AddRange(products);
                _appDbContext.SaveChanges();
            }

        }

    }
}