namespace Capstone.Products
{
    public class Gum : Product
    {
        public Gum(string productName, decimal price, int initialQuantity) : base(productName, price, initialQuantity)
        {
        }
        public override string GetMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
