using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyCatch.API.Models
{
    public class UserRegisterRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Errors { get; set; }

        public UserRegisterRequest()
        {
            Errors = new List<string>();
        }
    }
}