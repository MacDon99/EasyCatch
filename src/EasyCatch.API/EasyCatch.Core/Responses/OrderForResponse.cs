using System;
using System.Collections.Generic;
using EasyCatch.Core.Models;

namespace EasyCatch.Core.Responses
{
    public class OrderForResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}