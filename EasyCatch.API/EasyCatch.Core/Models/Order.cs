using System;
using System.Collections.Generic;

namespace EasyCatch.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }

        public Order()
        {
            Products =  new List<ProductToBuy>();
        }
        public void AddProduct(ProductToBuy product)
        {
            Products.Add(product);
            TotalPrice += product.Price * product.Quantity;
        }
    }
}