using Capstone.Products;
using Capstone.Providers;
using System.Collections.Generic;

namespace CapstoneTests.Providers
{
    class StubProductProvider : IProductProvider
    {
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        public IDictionary<string, Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(string slot, Product product)
        {
            products.Add(slot, product);
        }
    }
}
