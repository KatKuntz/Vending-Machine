using Capstone.Products;
using System.Collections.Generic;

namespace Capstone.Providers
{
    public interface IInventoryProvider
    {
        public IDictionary<string, Product> GetInventory();
    }
}
