using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class VendingMachine
    {
        decimal CurrentBalance { get; set; } = 0;
        Dictionary<string, Products.Product> VendMachDict = new Dictionary<string, Products.Product>();
        public VendingMachine(string slotID)
        {
        }
        public void FeedMoney(int deposit)
        {
            CurrentBalance += deposit;
        }
        public void GetInventory()
        {

        }
        public void Dispense(string slotId)
        {
            if (CurrentBalance>=VendMachDict[slotId].Price)
            {
                CurrentBalance =- VendMachDict[slotId].Price;
                Console.WriteLine($"{VendMachDict[slotId].ProductName} purchased for {VendMachDict[slotId].Price} with balance remaining of {CurrentBalance}");
                Console.WriteLine(VendMachDict[slotId]);
            }
            else
            {

            }
        }
        public void GetSalesReport()
        {

        }
    }
}
