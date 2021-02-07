namespace Capstone.Products
{
    public class Drink : Product
    {
        public Drink(string productName, decimal price, int initialQuantity) : base(productName, price, initialQuantity)
        {
        }
        public override string GetMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
