using System;
using System.Collections.Generic;

namespace EasyCatch.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public Address AddressToSend { get; private set; }
    }
}