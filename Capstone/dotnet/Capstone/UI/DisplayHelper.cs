using Capstone.Products;
using System;
using System.Collections.Generic;

namespace Capstone.UI
{
    static class DisplayHelper
    {
        public static void DisplayVendingItems(VendingMachine vendingMachine)
        {
            foreach (string slot in vendingMachine.Slots)
            {
                Product product = vendingMachine.GetItem(slot);
                if (product.CurrentQuantity > 0)
                {
                    Console.WriteLine($"{slot}. {product.ProductName} for {product.Price:C2}, {product.CurrentQuantity} available");
                }
                else
                {
                    Console.WriteLine($"{slot}. SOLD OUT");
                }
            }
        }

        public static string GetValidInput(string prompt, ICollection<string> validInputs, string errorMessage)
        {
            string userInput;
            string output = null;
            bool showErrorMessage = true;

            Console.WriteLine(prompt);
            userInput = Console.ReadLine();

            foreach (string validString in validInputs)
            {
                if (userInput.Equals(validString, StringComparison.OrdinalIgnoreCase))
                {
                    output = validString;
                    showErrorMessage = false;
                    break;
                }
            }

            if (showErrorMessage)
            {
                Console.WriteLine(errorMessage);
            }

            return output;
        }
    }
}
