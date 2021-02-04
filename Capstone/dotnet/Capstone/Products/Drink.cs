﻿namespace Capstone.Products
{
    public class Drink : Product
    {
        public Drink(string productName, decimal price) : base(productName, price)
        {
        }
        public override string GetMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
