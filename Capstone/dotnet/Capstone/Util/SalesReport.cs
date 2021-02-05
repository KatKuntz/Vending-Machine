using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Products;

namespace Capstone.Util
{
    public class SalesReport
    {
        public void GetSalesReport()
        {
            try
            {
                string directory = Environment.CurrentDirectory;
                string outputFile=$"Sales_Report_{DateTime.Now.ToString()}.txt";
                string outputFullPath = Path.Combine(directory, outputFile);
                using (StreamWriter sw = new StreamWriter(outputFullPath))
                {
                    decimal totalSales = 0;
                    IDictionary<string, Product> currentInventory= VendingMachine.GetCurrentInventory();
                    //need to create GetCurrentInventory in VendingMachine
                    foreach (KeyValuePair<string, Product> salesReportEntry in currentInventory)
                       
                    {
                        sw.WriteLine($"{salesReportEntry.Value.ProductName}|{salesReportEntry.Value.NumberSold}");
                        totalSales += salesReportEntry.Value.NumberSold;
                    }
                    sw.WriteLine($"\nTOTAL SALES ${totalSales}");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not create or write file for Sales Report", e);
            }

        }
    }
}
