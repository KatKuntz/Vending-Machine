using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Providers;
using Capstone.Products;
using Capstone.Util;

namespace Capstone
{
    class VendingMachine
    {
        decimal CurrentBalance { get; set; } = 0;
        public VendingMachine(IProductProvider provider)
            {

            }
        Dictionary<string, Product> VendMachDict = new Dictionary<string, Product>();
        public void FeedMoney(decimal deposit)
        {
            CurrentBalance += deposit;
            Console.WriteLine($"Balance of ${CurrentBalance}");
            Logger.Log($"FEED MONEY: ${deposit} \n{CurrentBalance}");
            //verify \n means new line
        }
        public void GetInventory()
        {
            foreach (KeyValuePair<string, Product> indivProduct in VendMachDict)
            {
                if(indivProduct.Value.CurrentQuantity>0)
                {
                    Console.WriteLine($"{indivProduct.Key}. {indivProduct.Value.ProductName} for ${indivProduct.Value.Price}");
                }
            }
        }
        public void Dispense(string slotId)
        {
            if (CurrentBalance>=VendMachDict[slotId].Price)
            {
                CurrentBalance =- VendMachDict[slotId].Price;
                VendMachDict[slotId].SellProduct();
                Console.WriteLine($"{VendMachDict[slotId].ProductName} purchased for {VendMachDict[slotId].Price} with balance remaining of {CurrentBalance}");
                Console.WriteLine(VendMachDict[slotId].GetMessage());
            }
            else
            {
                Console.WriteLine($"Current balance is less than the item price. You need ${VendMachDict[slotId].Price-CurrentBalance} to make this purchase");
            }
        }
        public void GetSalesReport()
        {

        }
    }
}
