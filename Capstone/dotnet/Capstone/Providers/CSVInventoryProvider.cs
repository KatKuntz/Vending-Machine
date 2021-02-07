using Capstone.Products;
using Capstone.Providers.Parsers;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Providers
{
    class CSVInventoryProvider : IInventoryProvider
    {
        private readonly string[] fileData;
        private readonly CSVInventoryParser parser;

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

            parser = new CSVInventoryParser(delimiter);
        }

        public IDictionary<string, Product> GetInventory()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            foreach (string line in fileData)
            {
                try
                {
                    string slotID = parser.GetProductCode(line);

                    // Check if a product has already been added to the given slot.
                    if (products.ContainsKey(slotID))
                    {
                        throw new ProvideProductsException($"Cannot add two products to the same slot: {slotID}");
                    }

                    Product product = parser.GetProduct(line);
                    products.Add(slotID, product);
                } catch (ParseException e)
                {
                    throw new ProvideProductsException("Error parsing a line in the input file.", e);
                }
            }

            return products;
        }
    }
}
