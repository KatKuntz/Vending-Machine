using Capstone.Products;
using System;

namespace CapstoneTests.Stubs
{
    class StubProductFactory : IProductFactory
    {
        private readonly bool throwException;

        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public string ProductType { get; private set; }
        public int InitialQuantity { get; private set; }

        public StubProductFactory(bool throwException)
        {
            this.throwException = throwException;
        }

        public Product MakeProduct(string productName, decimal price, string productType, int initialQuantity)
        {
            if (throwException)
            {
                throw new ArgumentException();
            }

            ProductName = productName;
            Price = price;
            ProductType = productType;
            InitialQuantity = initialQuantity;

            return null;
        }
    }
}
