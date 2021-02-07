using Capstone.Parsers;
using Capstone.Products;
using CapstoneTests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests.Parsers
{
    [TestClass]
    public class CSVInventoryParserTests
    {
        [TestMethod]
        public void GetProduct_TooFewFields_ThrowsException()
        {
            CSVInventoryParser parser = new CSVInventoryParser('|');

            Assert.ThrowsException<ParseException>(() => parser.GetProduct("||"));
        }

        [TestMethod]
        public void GetProductCode_TooFewFields_ThrowsException()
        {
            CSVInventoryParser parser = new CSVInventoryParser('|');

            Assert.ThrowsException<ParseException>(() => parser.GetProductCode("||"));
        }

        [TestMethod]
        public void GetProduct_TooManyFields_ThrowsException()
        {
            CSVInventoryParser parser = new CSVInventoryParser('|');

            Assert.ThrowsException<ParseException>(() => parser.GetProduct("||||"));
        }

        [TestMethod]
        public void GetProductCode_TooManyFields_ThrowsException()
        {
            CSVInventoryParser parser = new CSVInventoryParser('|');

            Assert.ThrowsException<ParseException>(() => parser.GetProductCode("||||"));
        }

        [TestMethod]
        public void GetProductCode_ExpectedInput_ReturnsProductCode()
        {
            CSVInventoryParser parser = new CSVInventoryParser('|');

            string input = "A1|||";
            string expected = "A1";
            string actual = parser.GetProductCode(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetProduct_NonNumericPrice_ThrowsException()
        {
            CSVInventoryParser parser = new CSVInventoryParser('|');

            string input = "||price|";

            Assert.ThrowsException<ParseException>(() => parser.GetProduct(input));
        }

        [TestMethod]
        public void GetProduct_ProductFactoryThrowsException_ThrowsParseException()
        {
            IProductFactory exceptionProductFactory = new MockProductFactory(true);
            CSVInventoryParser parser = new CSVInventoryParser('|', exceptionProductFactory);

            string input = "A1|TestName|1.25|Candy";

            Assert.ThrowsException<ParseException>(() => parser.GetProduct(input));
        }

        [TestMethod]
        public void GetProduct_CallsProductFactory_WithParsedParameters()
        {
            MockProductFactory mockFactory = new MockProductFactory(false);
            CSVInventoryParser parser = new CSVInventoryParser('|', mockFactory);

            string input = "A1|TestName|1.25|Candy";
            string expectedName = "TestName";
            decimal expectedPrice = 1.25M;
            string expectedType = "Candy";
            int expectedQuantity = 5;

            parser.GetProduct(input);

            Assert.AreEqual(expectedName, mockFactory.ProductName, "Expected product name not passed to ProductFactory");
            Assert.AreEqual(expectedPrice, mockFactory.Price, "Expected price not passed to ProductFactory");
            Assert.AreEqual(expectedType, mockFactory.ProductType, "Expected product type not passed to ProductFactory");
            Assert.AreEqual(expectedQuantity, mockFactory.InitialQuantity, "Expected quantity not passed to ProductFactory");
        }
    }
}
