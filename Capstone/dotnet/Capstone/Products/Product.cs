using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    public abstract class Product
    {
        public int CurrentQuantity { get; set; } = 5;
        public int CurrentRevenue { get; set; } = 0;
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public abstract string GetMessage();
    }
}
