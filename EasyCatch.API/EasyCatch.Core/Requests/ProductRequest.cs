namespace EasyCatch.Core.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Quantity { get; private set; }

        public void Add(int quantity)
        {
            Quantity += quantity;
        }
        public void ChangePrice(decimal price)
        {
            Price = price;
        }
    }
}