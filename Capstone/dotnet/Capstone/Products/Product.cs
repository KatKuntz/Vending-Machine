using System;
namespace Capstone.Products
{
    public abstract class Product
    {
        public int CurrentQuantity { get; private set; }
        public int NumberSold { get; private set; } = 0;
        public string ProductName { get; }
        public decimal Price { get; }
        public Product(string productName, decimal price, int initialQuantity)
        {
            if (initialQuantity < 0)
            {
                throw new ArgumentException("Initial quantity cannot be less than 0");
            }
            CurrentQuantity = initialQuantity;
            ProductName = productName;
            Price = price;
        }
        public void Sell()
        {
            if (CurrentQuantity == 0)
            {
                throw new InvalidOperationException("Inventory is at zero and cannot be sold");
            }
            CurrentQuantity--;
            NumberSold++;
        }
        public abstract string GetMessage();
    }
}
