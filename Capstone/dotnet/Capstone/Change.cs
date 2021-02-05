using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Change
    {
        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickles { get; private set; }
        public Change(decimal amount)
        {
            while (amount >= 0.25M)
            {
                amount = -.25M;
                Quarters++;
            }
            while (amount >= 0.10M)
            {
                amount = -.10M;
                Dimes++;
            }
            while (amount >= 0.05M)
            {
                amount = -.05M;
                Nickles++;
            }
        }
    }
}
