using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Products;

namespace Capstone.Util
{
    public class SalesReport
    {
        public static void WriteSalesReport(string fileName, VendingMachine vendingMachine)
        {
                string directory = Environment.CurrentDirectory;
                string outputFullPath = Path.Combine(directory, fileName);
                using (StreamWriter sw = new StreamWriter(outputFullPath))
                {
                    foreach (string slot in vendingMachine.Slots)
                    {
                        Product product = vendingMachine.GetItem(slot);
                        sw.WriteLine($"{product.ProductName}|{product.NumberSold}");
                    }
                    sw.WriteLine($"\nTOTAL SALES ${vendingMachine.TotalSales}");
                }
        }
    }
}
