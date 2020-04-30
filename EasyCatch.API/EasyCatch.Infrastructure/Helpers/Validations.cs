using System.Collections.Generic;
using System.Text.RegularExpressions;
using EasyCatch.API.Core.Requests;

namespace EasyCatch.API.Infrastructure.Helpers
{
    public class Validations
    {
        public List<string> ValidateUserRegister(UserRegisterRequest request)
        {
            request.Errors = ValidateLogin(request);
            request.Errors = ValidatePassword(request);
            request.Errors = ValidateEmail(request);
            request.Errors = ValidateName(request);
            request.Errors = ValidateSurname(request);

            return request.Errors;
        }

        public List<string> ValidateUserLogin(UserLoginRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.Login))
            {
                request.Errors.Add("Login cannot be empty!");
            }
            if(string.IsNullOrWhiteSpace(request.Password))
            {
                request.Errors.Add("Password cannot be empty!");
            }
            return request.Errors;

        }

        private List<string> ValidateLogin(UserRegisterRequest user)
        {
            var LoginRegex = new Regex(@"^[a-zA-Z0-9]+$");

            if(string.IsNullOrWhiteSpace(user.Login))
            {
                user.Errors.Add("Login is required!");
                return user.Errors;
            }

            if(!LoginRegex.IsMatch(user.Login))
                user.Errors.Add("Login can contain letters and numbers.");

            return user.Errors;
        }

        private List<string> ValidatePassword(UserRegisterRequest user)
        {
            var PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            if(string.IsNullOrWhiteSpace(user.Password))
            {
                user.Errors.Add("Password is required!");
                return user.Errors;
            }

            if(!PasswordRegex.IsMatch(user.Password))
                user.Errors.Add("Password must contain minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character.");

            return user.Errors;
        }

        private List<string> ValidateEmail(UserRegisterRequest user)
        {
            var EmailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

            if(string.IsNullOrWhiteSpace(user.Email))
            {
                user.Errors.Add("Email is required!");
                return user.Errors;
            }

            if(!EmailRegex.IsMatch(user.Email))
                user.Errors.Add("Email does not match the given rules.");

            return user.Errors;
        }

        private List<string> ValidateName(UserRegisterRequest user)
        {
            var NameRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(user.Name))
            {
                user.Errors.Add("Name is required!");
                return user.Errors;
            }

            if(!NameRegex.IsMatch(user.Name))
                user.Errors.Add("Name is not correct.");
                
            return user.Errors;
        }

        private List<string> ValidateSurname(UserRegisterRequest user)
        {
            var SurnameRegex = new Regex(@"^[a-zA-Z]+$");

            if(string.IsNullOrWhiteSpace(user.Surname))
            {
                user.Errors.Add("Surname is required!");
                return user.Errors;
            }

            if(!SurnameRegex.IsMatch(user.Surname))
                user.Errors.Add("Surname is not correct.");
                
            return user.Errors;
        }
    }
}