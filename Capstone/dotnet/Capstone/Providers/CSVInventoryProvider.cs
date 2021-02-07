using Capstone.Products;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Providers
{
    class CSVInventoryProvider : IInventoryProvider
    {
        private readonly string[] fileData;
        private readonly char delimiter;

        public CSVInventoryProvider(string filePath, char delimiter = ',')
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

        public IDictionary<string, Product> GetInventory()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            foreach (string line in fileData)
            {
                string slotID = GetProductCode(line);

                // Check if a product has already been added to the given slot.
                if (products.ContainsKey(slotID))
                {
                    throw new ProvideProductsException($"Cannot add two products to the same slot: {slotID}");
                }

                Product product = GetProduct(line);
                products.Add(slotID, product);
            }

            return products;
        }

        private string[] GetTokens(string csvLine)
        {
            // Ensure that the line has the right amount of fields
            string[] tokens = csvLine.Split(delimiter);
            if (tokens.Length != 4)
            {
                throw new ProvideProductsException($"Line not formatted correctly: {csvLine}");
            }
            return tokens;
        }

        public string GetProductCode(string csvLine)
        {
            string[] tokens = GetTokens(csvLine);

            return tokens[0];
        }

        public Product GetProduct(string csvLine)
        {
            string[] tokens = GetTokens(csvLine);

            // Get the product info from the fields.
            string productName = tokens[1];
            decimal price = GetProductPrice(tokens[2]);
            string productType = tokens[3];

            Product product;

            try
            {
                product = Product.MakeProduct(productName, price, productType);
            } catch (ArgumentException e)
            {
                throw new ProvideProductsException(e.Message, e);
            }

            return product;
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
    }
}
