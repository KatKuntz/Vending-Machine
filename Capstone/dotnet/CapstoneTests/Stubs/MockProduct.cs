using Capstone.Products;

namespace CapstoneTests.Stubs
{
    class MockProduct : Product
    {
        public bool SellCalled { get; private set; } = false;

        public MockProduct(string productName, decimal price, int initialQuantity) : base(productName, price, initialQuantity)
        {
        }

        public override string GetMessage()
        {
            return "Mock";
        }

        public override void Sell()
        {
            SellCalled = true;
        }
    }
}
