using System.Collections.Generic;

namespace EasyCatch.API.Core.Responses
{
    public class UserLoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public UserForResponse UserModel { get; set; }
        public List<string> Errors { get; set; }
        public UserLoginResponse()
        {
            Errors = new List<string>();
        }
    }
}