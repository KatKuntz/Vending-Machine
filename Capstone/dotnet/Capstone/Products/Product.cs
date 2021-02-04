namespace Capstone.Products
{
    public abstract class Product
    {
        public int CurrentQuantity { get; private set; } = 5;
        public int NumberSold { get; private set; } = 0;
        public string ProductName { get; }
        public decimal Price { get; }
        public abstract string GetMessage();
    }
}
