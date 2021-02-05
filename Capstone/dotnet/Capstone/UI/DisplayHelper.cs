using Capstone.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    static class DisplayHelper
    {
        public static void DisplayVendingItems(VendingMachine vendingMachine)
        {
            foreach (string slot in vendingMachine.Slots)
            {
                Product product = vendingMachine.GetItem(slot);
                Console.WriteLine($"{slot}. {product.ProductName} for {product.Price:C2}");
            }
        }
    }
}
