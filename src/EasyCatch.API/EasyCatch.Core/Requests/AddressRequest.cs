using System;
using System.Collections.Generic;

namespace EasyCatch.Core.Requests
{
    public class AddressRequest
    {
        public string OrderId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public List<string> Errors { get; set; }
        public AddressRequest()
        {
            Errors = new List<string>();
        }
    }
}