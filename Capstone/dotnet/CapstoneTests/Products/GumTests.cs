using Capstone.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests.Products
{
    [TestClass]
    public class GumTests
    {

        [TestMethod]
        public void InitialQuantity_Negative_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Gum("", 0, -1));
        }

        [TestMethod]
        public void Sell_Decreases_QuantityByOne()
        {
            Gum gum = new Gum("", 0M, 1);

            gum.Sell();

            Assert.AreEqual(0, gum.CurrentQuantity);
        }

        [TestMethod]
        public void Initial_NumberSold_IsZero()
        {
            Gum gum = new Gum("", 0M, 1);

            Assert.AreEqual(0, gum.NumberSold);
        }

        [TestMethod]
        public void Sell_Increases_NumberSoldByOne()
        {
            Gum gum = new Gum("", 0M, 1);

            gum.Sell();

            Assert.AreEqual(1, gum.NumberSold);
        }

        [TestMethod]
        public void Sell_WhenQuantityZero_ThrowsInvalidOperationException()
        {
            Gum gum = new Gum("", 0M, 0);

            Assert.ThrowsException<InvalidOperationException>(() => gum.Sell());
        }

        [TestMethod]
        public void GetMessage_Returns_CorrectMessage()
        {
            Gum gum = new Gum("", 0M, 0);

            string message = gum.GetMessage();
            string expected = "Chew Chew, Yum!";

            Assert.AreEqual(expected, message);
        }
    }
}
