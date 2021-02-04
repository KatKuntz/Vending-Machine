using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Chip: Product
    {
        public Chip():base("Chip")
        {
        }
        public override string GetMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
