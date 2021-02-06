﻿using Capstone.Products;
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
            string userInput = "";

            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();

                if (validInputs.Contains(userInput.ToUpper()))
                {
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return userInput.ToUpper();
        }
    }
}
