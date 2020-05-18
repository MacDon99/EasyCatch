using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCatch.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        //address
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        // public Address AddressToSend { get; set; }
        public Order()
        {
            Products = new List<ProductToBuy>();
            // AddressToSend = new Address();
        }
    }
}