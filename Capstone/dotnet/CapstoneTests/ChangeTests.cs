using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void Change_NegativeAmount_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Change(-1));
        }

        [TestMethod]
        public void Change_UnderFiveCents_ReturnsAllPennies()
        {
            decimal money = 0.03M;

            Change change = new Change(money);

            Assert.AreEqual(3, change.Pennies);
        }

        [TestMethod]
        public void Change_BetweenFiveAndTenCents_ReturnsNickelAndPennies()
        {
            decimal money = 0.07M;

            Change change = new Change(money);

            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(2, change.Pennies);
        }

        [TestMethod]
        public void Change_BetweenTenAndTwentyFiveCents_ReturnsDimesNickelsAndPennies()
        {
            decimal money = 0.17M;

            Change change = new Change(money);

            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(2, change.Pennies);
        }

        [TestMethod]
        public void Change_OverTwentyFiveCents_ReturnsQuartersDimesNickelsAndPennies()
        {
            decimal money = 0.42M;

            Change change = new Change(money);

            Assert.AreEqual(1, change.Quarters);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(1, change.Nickels);
            Assert.AreEqual(2, change.Pennies);
        }
    }
}
