using System;

namespace Capstone.Products
{
    class ProductFactory : IProductFactory
    {
        public Product MakeProduct(string productName, decimal price, string productType, int initialQuantity)
        {
            Product product;

            // Construct product based on the type
            if (productType == "Chip")
            {
                product = new Chip(productName, price, initialQuantity);
            }
            else if (productType == "Candy")
            {
                product = new Candy(productName, price, initialQuantity);
            }
            else if (productType == "Drink")
            {
                product = new Drink(productName, price, initialQuantity);
            }
            else if (productType == "Gum")
            {
                product = new Gum(productName, price, initialQuantity);
            }
            else
            {
                throw new ArgumentException($"Unknown product type: {productType}.");
            }

            return product;
        }
    }
}
