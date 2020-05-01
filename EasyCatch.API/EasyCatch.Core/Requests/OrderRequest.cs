using System.Collections.Generic;
using EasyCatch.Core.Models;

namespace EasyCatch.Core.Requests
{
    public class OrderRequest
    {
        List<ProductToBuy> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public Address AddressToSend { get; private set; }

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
        public void SetAddressToSend(Address address)
        {
            AddressToSend = address;
        }
    }
}