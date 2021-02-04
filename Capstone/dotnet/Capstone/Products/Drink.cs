using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    class Drink:Product
    {
        public override string GetMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
