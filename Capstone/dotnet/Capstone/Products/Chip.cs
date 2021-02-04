namespace Capstone.Products
{
    class Chip : Product
    {
        public Chip(string productName, decimal price) : base(productName, price)
        {
        }
        public override string GetMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
