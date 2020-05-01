using System.Collections.Generic;
using EasyCatch.Core.Models;

namespace EasyCatch.Core.Requests
{
    public class OrderRequest
    {
        List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public OrderRequest()
        {
            Products =  new List<ProductToBuy>();
            // AddressToSend =  new Address(){};
        }
        public void AddProduct(ProductToBuy product)
        {
            Products.Add(product);
            TotalPrice += product.Price * product.Quantity;
        }
        public void SetAddressToSend(string street, string houseNumber, string postCode, string city)
        {
            Street = street;
            HouseNumber = houseNumber;
            PostCode = postCode;
            City = city;
        }
    }
}