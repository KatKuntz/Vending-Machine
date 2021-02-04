using Capstone.Products;
using System.Collections.Generic;

namespace Capstone.Providers
{
    public interface IProductProvider
    {
        public IDictionary<string, Product> GetProducts();
    }
}
