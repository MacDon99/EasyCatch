namespace EasyCatch.API.Models
{
    public class UserRegisterResponse
    {
        public string Token { get; set; }
        public UserForResponse UserModel { get; set; }
    }
}