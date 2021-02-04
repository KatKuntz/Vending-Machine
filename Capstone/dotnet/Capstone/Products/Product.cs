using System;
namespace Capstone.Products
{
    public abstract class Product
    {
        public int CurrentQuantity { get; private set; } = 5;
        public int NumberSold { get; private set; } = 0;
        public string ProductName { get; }
        public decimal Price { get; }
        public void SellProduct()
        {
            if(CurrentQuantity==0)
            {
                throw new InvalidOperationException("Inventory is at zero and cannot be sold");
            }
            CurrentQuantity--;
            NumberSold++;
        }
        public Product(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;
        }
        public abstract string GetMessage();
    }
}
