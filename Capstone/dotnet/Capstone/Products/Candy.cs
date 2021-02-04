namespace Capstone.Products
{
    public class Candy : Product
    {
        public Candy(string productName, decimal price) : base(productName, price)
        {
        }
        public override string GetMessage()
        {
            return "Munch Munch, Yum!";
        }
    }
}
