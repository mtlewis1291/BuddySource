using System;
using System.IO;

namespace BuddyRework
{
    class Calculate
    {
        public static int CalculateNewAmount(int amount)
        {
            int newAmount = int.Parse(
                File.ReadAllText("Amount.txt")) + amount;
            return newAmount;
        }

        public static decimal CalculateNewPrice(decimal price)
        {
            decimal newPrice = decimal.Parse(
                File.ReadAllText("Price.txt")) + price;
            return newPrice;
        }
    }
}
