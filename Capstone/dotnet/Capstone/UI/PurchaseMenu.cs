using System;

namespace Capstone.UI
{
    static class PurchaseMenu
    {
        private static void PrintMenu(decimal currentBalance)
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"\nCurrent Money Provided: {currentBalance:C2}");
        }

        public static string Show(decimal currentBalance)
        {
            string userInput = "";

            bool validInput = false;
            while (!validInput)
            {
                PrintMenu(currentBalance);
                userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2" || userInput == "3")
                {
                    validInput = true;
                }
            }

            return userInput;
        }
    }
}
