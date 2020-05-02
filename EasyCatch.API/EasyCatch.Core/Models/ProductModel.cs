using System.Collections.Generic;

namespace EasyCatch.Core.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Quantity { get;  set; }
        public List<string> Errors { get; set; }

        public ProductModel()
        {
            Errors = new List<string>();
        }
    }
}