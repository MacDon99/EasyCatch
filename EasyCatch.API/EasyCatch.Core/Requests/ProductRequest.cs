using System.Collections.Generic;

namespace EasyCatch.Core.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Quantity { get;  set; }
        public List<string> Errors { get; set; }
        public ProductRequest()
        {
            Errors = new List<string>();
        }

        public void Add(int quantity)
        {
            Quantity += quantity;
        }
        public void ChangePrice(decimal price)
        {
            Price = price;
        }
    }
}