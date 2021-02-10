using Capstone.Products;
using System.Collections.Generic;

namespace Capstone.Providers
{
    public interface IInventoryProvider
    {
        IDictionary<string, Product> GetInventory();
    }
}
