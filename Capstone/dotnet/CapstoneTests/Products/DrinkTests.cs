using Capstone.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests.Products
{
    [TestClass]
    public class DrinkTests
    {

        [TestMethod]
        public void InitialQuantity_Negative_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Drink("", 0, -1));
        }

        [TestMethod]
        public void Sell_Decreases_QuantityByOne()
        {
            Drink drink = new Drink("", 0M, 1);

            drink.Sell();

            Assert.AreEqual(0, drink.CurrentQuantity);
        }

        [TestMethod]
        public void Initial_NumberSold_IsZero()
        {
            Drink drink = new Drink("", 0M, 1);

            Assert.AreEqual(0, drink.NumberSold);
        }

        [TestMethod]
        public void Sell_Increases_NumberSoldByOne()
        {
            Drink drink = new Drink("", 0M, 1);

            drink.Sell();

            Assert.AreEqual(1, drink.NumberSold);
        }

        [TestMethod]
        public void Sell_WhenQuantityZero_ThrowsInvalidOperationException()
        {
            Drink drink = new Drink("", 0M, 0);

            Assert.ThrowsException<InvalidOperationException>(() => drink.Sell());
        }

        [TestMethod]
        public void GetMessage_Returns_CorrectMessage()
        {
            Drink drink = new Drink("", 0M, 0);

            string message = drink.GetMessage();
            string expected = "Glug Glug, Yum!";

            Assert.AreEqual(expected, message);
        }
    }
}
