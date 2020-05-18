namespace EasyCatch.Core.Requests
{
    public class AddProductToOrderRequest
    {
        public string orderId { get; set; }
        public string productId { get; set; }
    }
}