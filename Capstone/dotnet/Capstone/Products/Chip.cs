namespace Capstone.Products
{
    public class Chip : Product
    {
        public Chip(string productName, decimal price, int initialQuantity) : base(productName, price, initialQuantity)
        {
        }
        public override string GetMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
