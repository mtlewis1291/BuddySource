using System;
using System.IO;

namespace BuddyRework
{
    class Calculate
    {
        public static int CalculateNewAmount(int amount)
        {
            int newAmount = Int32.Parse(
                File.ReadAllText(
                    "Amount.txt"))
                    + amount;
            return newAmount;
        }

        public static int CalculateNewPrice(int price)
        {
            int newPrice = Int32.Parse(
                File.ReadAllText(
                    "Price.txt"))
                    + price;
            return newPrice;
        }
    }
}
