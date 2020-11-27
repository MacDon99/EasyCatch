using System;

namespace EasyCatch.API.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}