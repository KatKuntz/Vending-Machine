namespace Capstone.Products
{
    class Gum : Product
    {
        public Gum(string productName, decimal price) : base(productName, price)
        {
        }
        public override string GetMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
