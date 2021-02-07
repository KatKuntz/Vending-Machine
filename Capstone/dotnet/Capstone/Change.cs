using System;

namespace Capstone
{
    public class Change
    {
        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickels { get; private set; }
        public int Pennies { get; private set; }
        public Change(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot make change for negative money.");
            }

            // Convert dollar amount to cents, discarding anything less than $0.01
            int cents = (int)(amount * 100);

            while (cents >= 25)
            {
                cents -= 25;
                Quarters++;
            }
            while (cents >= 10)
            {
                cents -= 10;
                Dimes++;
            }
            while (cents >= 5)
            {
                cents -= 5;
                Nickels++;
            }
            Pennies = cents;
        }
    }
}
