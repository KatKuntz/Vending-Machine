using Capstone.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests.Products
{
    [TestClass]
    public class CandyTests
    {

        [TestMethod]
        public void InitialQuantity_Negative_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Candy("", 0, -1));
        }

        [TestMethod]
        public void Sell_Decreases_QuantityByOne()
        {
            Candy candy = new Candy("", 0M, 1);

            candy.Sell();

            Assert.AreEqual(0, candy.CurrentQuantity);
        }

        [TestMethod]
        public void Initial_NumberSold_IsZero()
        {
            Candy candy = new Candy("", 0M, 1);

            Assert.AreEqual(0, candy.NumberSold);
        }

        [TestMethod]
        public void Sell_Increases_NumberSoldByOne()
        {
            Candy candy = new Candy("", 0M, 1);

            candy.Sell();

            Assert.AreEqual(1, candy.NumberSold);
        }

        [TestMethod]
        public void Sell_WhenQuantityZero_ThrowsInvalidOperationException()
        {
            Candy candy = new Candy("", 0M, 0);

            Assert.ThrowsException<InvalidOperationException>(() => candy.Sell());
        }

        [TestMethod]
        public void GetMessage_Returns_CorrectMessage()
        {
            Candy candy = new Candy("", 0M, 0);

            string message = candy.GetMessage();
            string expected = "Munch Munch, Yum!";

            Assert.AreEqual(expected, message);
        }
    }
}
