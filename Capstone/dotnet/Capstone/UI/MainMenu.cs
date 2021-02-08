namespace Capstone.UI
{
    static class MainMenu
    {
        public static string Show()
        {
            string prompt = "(1) Display Vending Machine Items\n"
                          + "(2) Purchase\n"
                          + "(3) Exit";
            string[] validInputs = { "1", "2", "3", "4" };
            string errorMessage = "Invalid selection, please try again.";
            return DisplayHelper.GetValidInput(prompt, validInputs, errorMessage);
        }
    }
}
