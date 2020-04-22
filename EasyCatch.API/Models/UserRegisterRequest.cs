using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EasyCatch.API.Models
{
    public class UserRegisterRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", 
        ErrorMessage = "Login can contain letters and numbers.")]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
        ErrorMessage = "Password must contain minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", 
        ErrorMessage = "Email field is not valid")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$",
        ErrorMessage="Name field is not valid.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$",
        ErrorMessage="Surname field is not valid.")]
        public string Surname { get; set; }
        public List<string> Errors { get; set; }

    }
}