using System;

namespace EasyCatch.Core.Models
{
    public class ProductToBuy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}