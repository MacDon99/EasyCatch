using EasyCatch.Core.Models;
using EasyCatch.Core.Requests;

namespace EasyCatch.Core.Responses
{
    public class ProductResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ProductRequest Product { get; set; }
    }
}