using Capstone.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests.Products
{
    [TestClass]
    public class ProductFactoryTests
    {
        [TestMethod]
        public void MakeProduct_UnknownProductType_ThrowsArgumentException()
        {
            ProductFactory factory = new ProductFactory();

            Assert.ThrowsException<ArgumentException>(() => factory.MakeProduct("",0M,"unknown",0));
        }

        [TestMethod]
        public void MakeProduct_CandyProductType_ReturnsCandyObject()
        {
            ProductFactory factory = new ProductFactory();

            Product product = factory.MakeProduct("", 0, "Candy", 0);

            Assert.AreEqual(typeof(Candy), product.GetType());
        }

        [TestMethod]
        public void MakeProduct_ChipProductType_ReturnsChipObject()
        {
            ProductFactory factory = new ProductFactory();

            Product product = factory.MakeProduct("", 0, "Chip", 0);

            Assert.AreEqual(typeof(Chip), product.GetType());
        }

        [TestMethod]
        public void MakeProduct_DrinkProductType_ReturnsDrinkObject()
        {
            ProductFactory factory = new ProductFactory();

            Product product = factory.MakeProduct("", 0, "Drink", 0);

            Assert.AreEqual(typeof(Drink), product.GetType());
        }

        [TestMethod]
        public void MakeProduct_GumProductType_ReturnsGumObject()
        {
            ProductFactory factory = new ProductFactory();

            Product product = factory.MakeProduct("", 0, "Gum", 0);

            Assert.AreEqual(typeof(Gum), product.GetType());
        }

        [TestMethod]
        public void MakeProduct_ReturnsCandy_WithPropertiesSet()
        {
            TestExpectedPropertiesOfType("Candy");
        }

        [TestMethod]
        public void MakeProduct_ReturnsChip_WithPropertiesSet()
        {
            TestExpectedPropertiesOfType("Chip");
        }

        [TestMethod]
        public void MakeProduct_ReturnsDrink_WithPropertiesSet()
        {
            TestExpectedPropertiesOfType("Drink");
        }

        [TestMethod]
        public void MakeProduct_ReturnsGum_WithPropertiesSet()
        {
            TestExpectedPropertiesOfType("Gum");
        }

        private static void TestExpectedPropertiesOfType(string productType)
        {
            ProductFactory factory = new ProductFactory();
            string name = "TestName";
            decimal price = 1.25M;
            int quantity = 5;

            Product product = factory.MakeProduct(name, price, productType, quantity);

            Assert.AreEqual(name, product.ProductName);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.CurrentQuantity);
        }
    }
}
