﻿using Capstone.Products;
using Capstone.Providers;
using Capstone.Util;
using System.Collections.Generic;

namespace Capstone
{
    public class VendingMachine
    {
        public decimal CurrentBalance { get; private set; } = 0;
        public IDictionary<string, Product> CurrentInventory { get; }
        public VendingMachine(IProductProvider provider)
        {
            CurrentInventory = provider.GetProducts();
        }

        public void FeedMoney(decimal deposit)
        {
            CurrentBalance += deposit;
            Logger.Log($"FEED MONEY: ${deposit} {CurrentBalance}");
        }
        /*public void GetInventory()
        {
            foreach (KeyValuePair<string, Product> indivProduct in CurrentInventory)
            {
                if(indivProduct.Value.CurrentQuantity>0)
                {
                    Console.WriteLine($"{indivProduct.Key}. {indivProduct.Value.ProductName} for ${indivProduct.Value.Price}");
                }
            }
        }*/
        public decimal GetPrice(string slotId)
        {
            return CurrentInventory[slotId].Price;
        }
        public void Dispense(string slotId)
        {
            CurrentBalance = -GetPrice(slotId);
            CurrentInventory[slotId].SellProduct();
            Logger.Log($"{CurrentInventory[slotId].ProductName} {slotId} ${CurrentBalance+GetPrice(slotId)} ${CurrentBalance}");
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
