using System.Collections.Generic;
using System.Text.RegularExpressions;
using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;

namespace EasyCatch.Infrastructure.Validators
{
    public class OrderValidations
    {
        public List<string> ValidateOrderAddress(AddressRequest address)
        {
            address.Errors = ValidateStreet(address);
            address.Errors = ValidateHouseNumber(address);
            address.Errors = ValidatePostCode(address);
            address.Errors = ValidateCity(address);
            return address.Errors;
        }

        private List<string> ValidateStreet(AddressRequest address)
        {
            var AddressRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(address.Street))
            {
                address.Errors.Add("Address street is required!");
                return address.Errors;
            }

            if(!AddressRegex.IsMatch(address.Street))
                address.Errors.Add("Address street is not correct.");

            return address.Errors;
        }
        private List<string> ValidateHouseNumber(AddressRequest address)
        {
            // var HouseNrRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(address.HouseNumber))
            {
                address.Errors.Add("Address house number is required!");
                return address.Errors;
            }

            // if(!HouseNrRegex.IsMatch(address.Street))
            //     address.Errors.Add("Address house number is not correct.");

            return address.Errors;
        }
        private List<string> ValidatePostCode(AddressRequest address)
        {
            // var HouseNrRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(address.PostCode))
            {
                address.Errors.Add("Address PostCode is required!");
                return address.Errors;
            }

            // if(!HouseNrRegex.IsMatch(address.Street))
            //     address.Errors.Add("Address house number is not correct.");

            return address.Errors;
        }

        private List<string> ValidateCity(AddressRequest address)
        {
             var CityRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(address.City))
            {
                address.Errors.Add("Address City is required!");
                return address.Errors;
            }

            if(!CityRegex.IsMatch(address.City))
                address.Errors.Add("Address City is not correct.");

            return address.Errors;
        }
    }
}