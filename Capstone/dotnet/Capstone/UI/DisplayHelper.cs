using Capstone.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI
{
    static class DisplayHelper
    {
        public static void DisplayVendingItems(VendingMachine vendingMachine)
        {
            foreach (string slot in vendingMachine.Slots)
            {
                Product product = vendingMachine.GetItem(slot);
                Console.WriteLine($"{slot}. {product.ProductName} for {product.Price:C2}");
            }
        }

        public static string GetValidInput(string prompt, ICollection<string> validInputs, string errorMessage)
        {
            string userInput = "";

            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();

                if (validInputs.Contains(userInput))
                {
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return userInput;
        }
    }
}
