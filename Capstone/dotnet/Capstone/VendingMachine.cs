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

        public VendingMachine(IProductProvider provider)
        {
            currentInventory = provider.GetProducts();
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
            Logger.Log($"FEED MONEY: ${dollarAmount} {CurrentBalance}");
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
            CurrentBalance -= item.Price;
            TotalSales += item.Price;
            Logger.Log($"{item.ProductName} {slotId} ${CurrentBalance + item.Price} ${CurrentBalance}");
            //Console.WriteLine($"{CurrentInventory[slotId].ProductName} purchased for {CurrentInventory[slotId].Price} with balance remaining of {CurrentBalance}");
            //Console.WriteLine(CurrentInventory[slotId].GetMessage());
            //Console.WriteLine($"Current balance is less than the item price. You need ${CurrentInventory[slotId].Price-CurrentBalance} to make this purchase");
        }
        public void ReturnChange()
        {
            decimal initialBalance = CurrentBalance;
            int numOfQuarters = 0;
            int numOfDimes = 0;
            int numOfNickles = 0;
            int numOfPennies = 0;
            while (CurrentBalance >= 0.25M)
            {
                CurrentBalance = -.25M;
                numOfQuarters++;
            }
            while (CurrentBalance >= 0.10M)
            {
                CurrentBalance = -.10M;
                numOfDimes++;
            }
            while (CurrentBalance >= 0.05M)
            {
                CurrentBalance = -.05M;
                numOfNickles++;
            }
            while (CurrentBalance >= 0.01M)
            {
                CurrentBalance = -.01M;
                numOfPennies++;
            }
            Logger.Log($"GIVE CHANGE: ${initialBalance} ${CurrentBalance}");
        }
    }
}
