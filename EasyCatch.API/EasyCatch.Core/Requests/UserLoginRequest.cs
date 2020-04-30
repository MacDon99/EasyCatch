using System.Collections.Generic;

namespace EasyCatch.API.Core.Requests
{
    public class UserLoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Errors { get; set; }

        public UserLoginRequest()
        {
            Errors = new List<string>();
        }
    }
}