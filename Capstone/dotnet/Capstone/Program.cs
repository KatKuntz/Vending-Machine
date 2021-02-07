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
            try
            {
                IInventoryProvider provider = new CSVInventoryProvider("vendingmachine.csv", '|');
                VendingMachine vendingMachine = new VendingMachine(provider);

                MainMenuLoop(vendingMachine);
            }
            catch (ProvideInventoryException ex)
            {
                Console.WriteLine($"Error loading inventory: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"\t{ex.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occured: {ex.Message}");
            }
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
                    string prompt = "Insert 1,2,5 or 10 dollar bills or enter 'q' to exit";
                    string[] validBills = {"1", "2", "5", "10" };
                    string errorMessage = "Invalid bill inserted";
                    string moneyString = DisplayHelper.GetValidInput(prompt, validBills, errorMessage);
                    if (moneyString != null)
                    {
                        int moneyDeposit = int.Parse(moneyString);
                        vendingMachine.FeedMoney(moneyDeposit);
                    }
                }
                else if (userInput == "2")
                {
                    DisplayHelper.DisplayVendingItems(vendingMachine);
                    string prompt = "Input Slot I.D. or 'q' to exit";
                    string errorMessage = "Invalid Slot Selected";
                    ICollection<string> stockedSlots = new List<string>();
                    foreach (string slot in vendingMachine.Slots)
                    {
                        Product productSlotted = vendingMachine.GetItem(slot);
                        if (productSlotted.CurrentQuantity > 0)
                        {
                            stockedSlots.Add(slot);
                        }
                    }
                    string selectedSlot = DisplayHelper.GetValidInput(prompt, stockedSlots, errorMessage);

                    if (selectedSlot != null)
                    {
                        Product product = vendingMachine.GetItem(selectedSlot);
                        if (vendingMachine.CurrentBalance >= product.Price)
                        {
                            vendingMachine.Dispense(selectedSlot);
                            Console.WriteLine($"{product.ProductName} purchased for {product.Price:C2} with balance remaining of {vendingMachine.CurrentBalance:C2}");
                            Console.WriteLine(product.GetMessage());
                        }
                        else if (vendingMachine.CurrentBalance == 0)
                        {
                            Console.WriteLine("Must deposit money before making a selection");
                        }
                        else
                        {
                            Console.WriteLine($"Current balance is less than the item price. You need ${product.Price - vendingMachine.CurrentBalance} to make this purchase");
                        }
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
