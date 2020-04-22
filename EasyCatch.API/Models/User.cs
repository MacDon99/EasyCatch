using System;
using System.Net.Mail;

namespace EasyCatch.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public MailAddress Email { get; set; }
        public string FullName { get; set; }
    }
}