using Capstone.Products;
using Capstone.Providers;
using System.Collections.Generic;

namespace CapstoneTests.Providers
{
    class StubInventoryProvider : IInventoryProvider
    {
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        public IDictionary<string, Product> GetInventory()
        {
            return products;
        }

        public void AddProduct(string slot, Product product)
        {
            products.Add(slot, product);
        }

        public List<string> GetSlots()
        {
            return new List<string>(products.Keys);
        }
    }
}
