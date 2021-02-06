using Capstone.Products;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Providers
{
    class CSVProductProvider : IProductProvider
    {
        private readonly string[] fileData;
        private readonly char delimiter;

        public CSVProductProvider(string filePath, char delimiter = ',')
        {
            try
            {
                fileData = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new ProvideProductsException("Failed to read data from input file.", ex);
            }

            this.delimiter = delimiter;
        }

        public IDictionary<string, Product> GetProducts()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            foreach (string line in fileData)
            {
                ProcessProductString(line, products);
            }

            return products;
        }

        private void ProcessProductString(string productString, Dictionary<string, Product> products)
        {
            // Ensure that the line has the right amount of fields
            string[] tokens = productString.Split(delimiter);
            if (tokens.Length != 4)
            {
                throw new ProvideProductsException($"Line not formatted correctly: {productString}");
            }

            // Get the product info from the fields.
            string slotName = tokens[0];
            string productName = tokens[1];
            decimal price = GetProductPrice(tokens[2]);
            string productType = tokens[3];

            // Check if a product has already been added to the given slot.
            if (products.ContainsKey(slotName))
            {
                throw new ProvideProductsException($"Cannot add two products to the same slot: {slotName}");
            }

            Product product = MakeProduct(productName, price, productType);
            products.Add(slotName, product);
        }

        private decimal GetProductPrice(string priceString)
        {
            decimal price;
            try
            {
                price = decimal.Parse(priceString);
            }
            catch (Exception e)
            {
                throw new ProvideProductsException($"Failed to read price of product: {priceString}.", e);
            }
            return price;
        }

        private Product MakeProduct(string productName, decimal price, string productType)
        {
            Product product;
            int initialQuantity = 5;
            
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
                throw new ProvideProductsException($"Unknown product type: {productType}.");
            }

            return product;
        }
    }
}
