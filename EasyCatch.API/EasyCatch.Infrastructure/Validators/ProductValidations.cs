using System.Collections.Generic;
using System.Text.RegularExpressions;
using EasyCatch.Core.Requests;

namespace EasyCatch.Infrastructure.Validators
{
    public class ProductValidations
    {
        public List<string> ValidateProduct(ProductRequest product)
        {
            product.Errors = ValidateName(product);
            product.Errors = ValidateDescription(product);
            return product.Errors;
        }

        private List<string> ValidateName(ProductRequest product)
        {
            var NameRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(product.Name))
            {
                product.Errors.Add("Product name is required!");
                return product.Errors;
            }

            if(!NameRegex.IsMatch(product.Name))
                product.Errors.Add("Product name is not correct.");

            return product.Errors;
        }
        private List<string> ValidateDescription(ProductRequest product)
        {
            //^(.|\s)*[a-zA-Z]+(.|\s)*$
            var DescriptionRegex = new Regex(@"^(.|\s)*[a-zA-Z]+(.|\s)*$");

            if(string.IsNullOrWhiteSpace(product.Description))
            {
                product.Errors.Add("Product description is required!");
                return product.Errors;
            }

            if(!DescriptionRegex.IsMatch(product.Description))
                product.Errors.Add("Product description is not correct.");

            return product.Errors;
        }
    }
}