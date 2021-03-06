using Capstone.Products;
using Capstone.Providers;
using Capstone.UI;
using Capstone.Util;
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
                else if (inputLine == "4")
                {
                    string dateTimeString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    string outputFile = $"Sales_Report_{dateTimeString}.txt";
                    try
                    {
                        Console.WriteLine($"Writing sales report to {outputFile}");
                        SalesReport.WriteSalesReport(outputFile, vendingMachine);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed to write sales report: {e.Message}");
                    }
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
                    string basePrompt = "Insert 1,2,5 or 10 dollar bills or enter 'q' to exit";
                    string[] validInputs = { "q", "1", "2", "5", "10" };
                    string errorMessage = "Invalid bill inserted";
                    bool feedingBills = true;

                    while (feedingBills)
                    {
                        string prompt = $"{basePrompt}\nCurrent Money Provided: {vendingMachine.CurrentBalance:C2}";
                        string moneyString = DisplayHelper.GetValidInput(prompt, validInputs, errorMessage);
                        if (moneyString != null)
                        {
                            if (moneyString != "q")
                            {
                                int moneyDeposit = int.Parse(moneyString);
                                vendingMachine.FeedMoney(moneyDeposit);
                            }
                            else
                            {
                                feedingBills = false;
                            }
                        }
                    }
                }
                else if (userInput == "2")
                {
                    DisplayHelper.DisplayVendingItems(vendingMachine);
                    string prompt = "Input Slot I.D. or 'q' to exit";
                    string errorMessage = "Invalid Slot Selected";

                    List<string> validInputs = new List<string>(vendingMachine.Slots);
                    validInputs.Add("q");

                    string selectedSlot = DisplayHelper.GetValidInput(prompt, validInputs, errorMessage);

                    if (selectedSlot != null && selectedSlot != "q")
                    {
                        Product product = vendingMachine.GetItem(selectedSlot);
                        if (product.CurrentQuantity <= 0)
                        {
                            Console.WriteLine($"Sorry, that item is sold out.");
                        }
                        else if (vendingMachine.CurrentBalance >= product.Price)
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
                    Console.WriteLine($"Dispensing {change.Quarters} quarters, {change.Dimes} dimes, and {change.Nickels} nickels");
                    inMenu = false;
                }
            }
        }
    }
}
