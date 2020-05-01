using System;
using System.Collections.Generic;

namespace EasyCatch.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        //address
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}