using System.Collections.Generic;

namespace EasyCatch.API.Models
{
    public class UserRegisterResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public UserForResponse UserModel { get; set; }
        public List<string> Errors { get; set; }
    }
}