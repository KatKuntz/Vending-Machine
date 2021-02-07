using Capstone.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests.Products
{
    [TestClass]
    public class ChipTests
    {

        [TestMethod]
        public void InitialQuantity_Negative_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Chip("", 0, -1));
        }

        [TestMethod]
        public void Sell_Decreases_QuantityByOne()
        {
            Chip chip = new Chip("", 0M, 1);

            chip.Sell();

            Assert.AreEqual(0, chip.CurrentQuantity);
        }

        [TestMethod]
        public void Initial_NumberSold_IsZero()
        {
            Chip chip = new Chip("", 0M, 1);

            Assert.AreEqual(0, chip.NumberSold);
        }

        [TestMethod]
        public void Sell_Increases_NumberSoldByOne()
        {
            Chip chip = new Chip("", 0M, 1);

            chip.Sell();

            Assert.AreEqual(1, chip.NumberSold);
        }

        [TestMethod]
        public void Sell_WhenQuantityZero_ThrowsInvalidOperationException()
        {
            Chip chip = new Chip("", 0M, 0);

            Assert.ThrowsException<InvalidOperationException>(() => chip.Sell());
        }

        [TestMethod]
        public void GetMessage_Returns_CorrectMessage()
        {
            Chip chip = new Chip("", 0M, 0);

            string message = chip.GetMessage();
            string expected = "Crunch Crunch, Yum!";

            Assert.AreEqual(expected, message);
        }
    }
}
