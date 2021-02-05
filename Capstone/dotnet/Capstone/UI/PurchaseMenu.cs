using Capstone.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    static class PurchaseMenu
    {
        public static void Show(VendingMachine vendingMachine)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"\nCurrent Money Provided: {vendingMachine.CurrentBalance:C2}");
                string inputLine = Console.ReadLine();
                if (inputLine == "1")
                {
                    Console.WriteLine("Insert 1,2,5 or 10 dollar bills");
                    int moneyDeposit = int.Parse(Console.ReadLine());
                    vendingMachine.FeedMoney(moneyDeposit);
                }
                else if (inputLine == "2")
                {
                    DisplayHelper.DisplayVendingItems(vendingMachine);
                    Console.WriteLine("Input Slot I.D.");
                    string input = Console.ReadLine();
                    if(vendingMachine.Slots.Contains(input))
                    {
                        Product product = vendingMachine.GetItem(input);
                        if (vendingMachine.CurrentBalance > product.Price)
                        {
                            vendingMachine.Dispense(input);
                            Console.WriteLine($"{product.ProductName} purchased for {product.Price} with balance remaining of {vendingMachine.CurrentBalance}");
                            Console.WriteLine(product.GetMessage());
                        }
                        //Console.WriteLine($"Current balance is less than the item price. You need ${product.Price - vendingMachine.CurrentBalance} to make this purchase");
                    }
                }
                else if (inputLine == "3")
                {
                    Change change = vendingMachine.ReturnChange();
                    Console.WriteLine($"Dispensing {change.Quarters} quarters, {change.Dimes} dimes, and {change.Nickles} nickles");
                    inMenu = false;
                }
            }
        }
    }
}
