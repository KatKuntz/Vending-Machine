using Capstone.Products;
using Capstone.Providers;
using Capstone.UI;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductProvider provider = new CSVProductProvider("vendingmachine.csv",'|');
            VendingMachine vendingMachine = new VendingMachine(provider);
            MainMenu.Show(vendingMachine);
        }
    }
}
