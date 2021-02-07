using Capstone.Products;
using System;

namespace Capstone.Parsers
{
    public class CSVInventoryParser
    {
        private readonly char delimiter;
        private IProductFactory productFactory;

        public CSVInventoryParser(char delimiter) : this(delimiter, new ProductFactory())
        {

        }

        public CSVInventoryParser(char delimiter, IProductFactory productFactory)
        {
            this.delimiter = delimiter;
            this.productFactory = productFactory;
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

            int initialQuantity = 5;

            Product product;
            try
            {
                product = productFactory.MakeProduct(productName, price, productType, initialQuantity);
            }
            catch (ArgumentException e)
            {
                throw new ParseException(e.Message, e);
            }

            return product;
        }

        private string[] GetTokens(string csvLine)
        {
            // Ensure that the line has the right amount of fields
            string[] tokens = csvLine.Split(delimiter);
            if (tokens.Length != 4)
            {
                throw new ParseException($"Line not formatted correctly: {csvLine}");
            }
            return tokens;
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
                throw new ParseException($"Failed to read price of product: {priceString}.", e);
            }
            return price;
        }
    }
}
