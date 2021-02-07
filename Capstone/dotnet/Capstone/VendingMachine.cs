using Capstone.Products;
using Capstone.Providers;
using Capstone.Util;
using System;
using System.Collections.Generic;

namespace Capstone
{
    public class VendingMachine
    {
        public decimal CurrentBalance { get; private set; } = 0;
        public decimal TotalSales { get; private set; } = 0;

        private readonly IDictionary<string, Product> currentInventory;

        public ICollection<string> Slots
        {
            get { return currentInventory.Keys; }
        }

        public VendingMachine(IInventoryProvider provider)
        {
            currentInventory = provider.GetInventory();
        }

        public bool AcceptsBill(int dollarAmount)
        {
            List<int> validBills = new List<int>() { 1, 2, 5, 10 };
            return validBills.Contains(dollarAmount);
        }

        public void FeedMoney(int dollarAmount)
        {
            if (!AcceptsBill(dollarAmount))
            {
                throw new InvalidOperationException($"Cannot accept bill value: {dollarAmount}");
            }
            CurrentBalance += dollarAmount;
            Logger.Log($"FEED MONEY: {dollarAmount:C2} {CurrentBalance:C2}");
        }

        public Product GetItem(string slotId)
        {
            if (!Slots.Contains(slotId))
            {
                throw new InvalidOperationException($"{slotId} is not a valid slot in this machine.");
            }
            return currentInventory[slotId];
        }

        public void Dispense(string slotId)
        {
            Product item = GetItem(slotId);
            if (CurrentBalance < item.Price)
            {
                throw new InvalidOperationException("Not enough money to buy item.");
            }
            if (item.CurrentQuantity <= 0)
            {
                throw new InvalidOperationException("Cannot dispense item: it is sold out.");
            }
            item.SellProduct();
            decimal initialBalance = CurrentBalance;
            CurrentBalance -= item.Price;
            TotalSales += item.Price;
            Logger.Log($"{item.ProductName} {slotId} {initialBalance:C2} {CurrentBalance:C2}");

        }
        public Change ReturnChange()
        {
            decimal initialBalance = CurrentBalance;
            Change change = new Change(CurrentBalance);
            Logger.Log($"GIVE CHANGE: {initialBalance:C2} $0.00");
            return change;
        }
    }
}
