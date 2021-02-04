using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Drink:Product
    {
        public Drink() : base("Drink")
        {
        }
        public override string GetMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
