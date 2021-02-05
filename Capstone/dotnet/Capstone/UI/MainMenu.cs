using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    static class MainMenu
    {
        public static void Show(VendingMachine vendingMachine)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");
                string inputLine = Console.ReadLine();
                if (inputLine == "1")
                {
                    DisplayHelper.DisplayVendingItems(vendingMachine);
                }
                else if (inputLine == "2")
                {
                    PurchaseMenu.Show(vendingMachine);
                }
                else if (inputLine == "3")
                {
                    running = false;
                }
            }
        }
    }
}
