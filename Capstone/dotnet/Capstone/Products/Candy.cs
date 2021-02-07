namespace Capstone.Products
{
    public class Candy : Product
    {
        public Candy(string productName, decimal price, int initialQuantity) : base(productName, price, initialQuantity)
        {
        }
        public override string GetMessage()
        {
            return "Munch Munch, Yum!";
        }
    }
}
