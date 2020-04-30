using System.Collections.Generic;

namespace EasyCatch.API.Models
{
    public class UserLoginResponse
    {
        public string Token { get; set; }
        public UserForResponse UserModel { get; set; }
        public List<string> Errors { get; set; }
        public UserLoginResponse()
        {
            Errors = new List<string>();
        }
    }
}