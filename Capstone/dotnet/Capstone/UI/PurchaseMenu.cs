namespace Capstone.UI
{
    static class PurchaseMenu
    {
        public static string Show(decimal currentBalance)
        {
            string prompt = "(1) Feed Money\n"
                          + "(2) Select Product\n"
                          + "(3) Finish Transaction\n"
                          + $"\nCurrent Money Provided: {currentBalance:C2}";

            string[] validInputs = { "1", "2", "3" };
            string errorMessage = "Invalid selection, please try again.";

            return DisplayHelper.GetValidInput(prompt, validInputs, errorMessage);
        }
    }
}
