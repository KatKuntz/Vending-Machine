using System;

namespace Capstone.UI
{
    static class MainMenu
    {
        private static void PrintMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
        }

        public static string Show()
        {
            string userInput = "";
            bool validInput = false;
            while (!validInput)
            {
                PrintMenu();
                userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
                {
                    validInput = true;
                }
            }
            return userInput;
        }
    }
}
