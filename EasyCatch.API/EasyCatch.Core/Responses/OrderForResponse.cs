using System.Collections.Generic;
using EasyCatch.Core.Models;

namespace EasyCatch.Core.Responses
{
    public class OrderForResponse
    {
        public List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public OrderForResponse()
        {
            Products = new List<ProductToBuy>();
        }
    }
}