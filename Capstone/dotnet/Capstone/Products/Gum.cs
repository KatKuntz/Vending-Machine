using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    class Gum:Product
    {
        public Gum() : base("Gum")
        {
        }
        public override string GetMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
