using Capstone.Products;
using Capstone.Providers;
using System.Collections.Generic;

namespace CapstoneTests.Providers
{
    class StubProductProvider : IProductProvider
    {
        List<Product> products = new List<Product>();

        public IList<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
