using Capstone;
using Capstone.Products;
using CapstoneTests.Providers;
using CapstoneTests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        private VendingMachine GetEmptyVendingMachine()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            return new VendingMachine(provider);
        }

        [TestMethod]
        public void Slots_ReturnsSlots_FromProvider()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            provider.AddProduct("A1", new Candy("candy", 0.10M, 1));
            VendingMachine machine = new VendingMachine(provider);

            CollectionAssert.AreEquivalent(provider.GetSlots(), machine.Slots);
        }

        [TestMethod]
        public void GetItem_InvalidItem_ThrowsException()
        {
            VendingMachine machine = GetEmptyVendingMachine();

            Assert.ThrowsException<InvalidOperationException>(() => machine.GetItem("invalid"));
        }

        [TestMethod]
        public void GetItem_ValidItem_ReturnsCorrectProduct()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            Product product = new Candy("Candy", 1M, 3);
            provider.AddProduct("A1", product);

            VendingMachine machine = new VendingMachine(provider);
            Product result = machine.GetItem("A1");

            Assert.AreEqual(product, result);
        }

        [TestMethod]
        public void FeedMoney_NegativeValue_ThrowsArgumentException()
        {
            VendingMachine machine = GetEmptyVendingMachine();

            Assert.ThrowsException<ArgumentException>(() => machine.FeedMoney(-1));
        }

        [TestMethod]
        public void FeedMoney_ValidValue_IncreasesCurrentBalance()
        {
            VendingMachine machine = GetEmptyVendingMachine();

            machine.FeedMoney(3);

            Assert.AreEqual(3, machine.CurrentBalance);
        }

        [TestMethod]
        public void CurrentBalance_InitiallyZero()
        {
            VendingMachine machine = GetEmptyVendingMachine();

            Assert.AreEqual(0, machine.CurrentBalance);
        }

        [TestMethod]
        public void Dispense_NotEnoughMoney_ThrowsInvalidOperationException()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            provider.AddProduct("A1", new Candy("", 1M, 1));
            VendingMachine machine = new VendingMachine(provider);

            Assert.ThrowsException<InvalidOperationException>(() => machine.Dispense("A1"));
        }

        [TestMethod]
        public void Dispense_SoldOut_ThrowsInvalidOperationException()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            provider.AddProduct("A1", new Candy("", 1M, 0));
            VendingMachine machine = new VendingMachine(provider);
            machine.FeedMoney(3);

            Assert.ThrowsException<InvalidOperationException>(() => machine.Dispense("A1"));
        }

        [TestMethod]
        public void Dispense_InvalidSlot_ThrowsInvalidOperationException()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            provider.AddProduct("A1", new Candy("", 1M, 1));
            VendingMachine machine = new VendingMachine(provider);
            machine.FeedMoney(3);

            Assert.ThrowsException<InvalidOperationException>(() => machine.Dispense("invalid"));
        }

        [TestMethod]
        public void Dispense_ExpectedInput_DecreasesBalanceByPrice()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            provider.AddProduct("A1", new Candy("", 1M, 1));
            VendingMachine machine = new VendingMachine(provider);
            machine.FeedMoney(3);

            machine.Dispense("A1");

            Assert.AreEqual(2, machine.CurrentBalance);
        }

        [TestMethod]
        public void Dispense_ExpectedInput_IncreasesTotalSalesByPrice()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            provider.AddProduct("A1", new Candy("", 1M, 1));
            VendingMachine machine = new VendingMachine(provider);
            machine.FeedMoney(3);

            machine.Dispense("A1");

            Assert.AreEqual(1, machine.TotalSales);
        }

        [TestMethod]
        public void Dispense_ExpectedInput_CallsSellOnProduct()
        {
            StubInventoryProvider provider = new StubInventoryProvider();
            MockProduct mock = new MockProduct("", 1M, 1);
            provider.AddProduct("A1", mock);

            VendingMachine machine = new VendingMachine(provider);
            machine.FeedMoney(3);

            machine.Dispense("A1");

            Assert.IsTrue(mock.SellCalled);
        }

        [TestMethod]
        public void ReturnChange_SetsBalance_ToZero()
        {
            VendingMachine machine = GetEmptyVendingMachine();

            machine.FeedMoney(3);
            machine.ReturnChange();

            Assert.AreEqual(0, machine.CurrentBalance);
        }

        [TestMethod]
        public void ReturnChange_GetsChangeObject_WithCurrentBalance()
        {
            VendingMachine machine = GetEmptyVendingMachine();

            machine.FeedMoney(1);

            Change change = machine.ReturnChange();
            Change expected = new Change(1);

            Assert.AreEqual(expected.Quarters, change.Quarters);
            Assert.AreEqual(expected.Dimes, change.Dimes);
            Assert.AreEqual(expected.Nickels, change.Nickels);
            Assert.AreEqual(expected.Pennies, change.Pennies);
        }
    }
}
