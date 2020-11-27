using System.Collections.Generic;

namespace EasyCatch.Core.Responses
{
    public class OrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public OrderForResponse Order { get; set; }
    }
}