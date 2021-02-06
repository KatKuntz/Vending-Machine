﻿using Capstone.Products;
using Capstone.Providers;
using Capstone.UI;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            IInventoryProvider provider = new CSVInventoryProvider("vendingmachine.csv", '|');
            VendingMachine vendingMachine = new VendingMachine(provider);

            MainMenuLoop(vendingMachine);
        }

        private static void MainMenuLoop(VendingMachine vendingMachine)
        {
            bool running = true;
            while (running)
            {
                string inputLine = MainMenu.Show();
                if (inputLine == "1")
                {
                    DisplayHelper.DisplayVendingItems(vendingMachine);
                }
                else if (inputLine == "2")
                {
                    PurchaseItemLoop(vendingMachine);
                }
                else if (inputLine == "3")
                {
                    running = false;
                }
            }
        }

        private static void PurchaseItemLoop(VendingMachine vendingMachine)
        {
            bool inMenu = true;
            while (inMenu)
            {
                string userInput = PurchaseMenu.Show(vendingMachine.CurrentBalance);
                if (userInput == "1")
                {
                    string prompt = "Insert 1,2,5 or 10 dollar bills";
                    string[] validBills = { "1", "2", "5", "10" };
                    string errorMessage = "Invalid bill inserted";
                    string moneyString = DisplayHelper.GetValidInput(prompt, validBills, errorMessage);
                    int moneyDeposit = int.Parse(moneyString);
                    vendingMachine.FeedMoney(moneyDeposit);
                }
                else if (userInput == "2")
                {
                    DisplayHelper.DisplayVendingItems(vendingMachine);
                    string prompt = "Input Slot I.D.";
                    string errorMessage = "Invalid Slot Selected";
                    string selectedSlot = DisplayHelper.GetValidInput(prompt, vendingMachine.Slots, errorMessage);

                    Product product = vendingMachine.GetItem(selectedSlot);
                    if (vendingMachine.CurrentBalance >= product.Price)
                    {
                        vendingMachine.Dispense(selectedSlot);
                        Console.WriteLine($"{product.ProductName} purchased for {product.Price:C2} with balance remaining of {vendingMachine.CurrentBalance:C2}");
                        Console.WriteLine(product.GetMessage());
                    }
                    else
                    {
                        Console.WriteLine($"Current balance is less than the item price. You need ${product.Price - vendingMachine.CurrentBalance} to make this purchase");
                    }
                }
                else if (userInput == "3")
                {
                    Change change = vendingMachine.ReturnChange();
                    Console.WriteLine($"Dispensing {change.Quarters} quarters, {change.Dimes} dimes, and {change.Nickles} nickles");
                    inMenu = false;
                }
            }
        }
    }
}
