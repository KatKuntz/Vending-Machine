﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Candy: Product
    {
        public Candy() : base("Candy")
        {
        }
        public override string GetMessage()
        {
            return "Munch Munch, Yum!";
        }
    }
}
