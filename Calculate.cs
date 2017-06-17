using System;
using System.IO;

namespace BuddyRework
{
    class Calculate
    {
        public static int CalculateNewUnits(int units)
        {
            int newUnits = int.Parse(
                File.ReadAllText("Inventory.txt")) + units;
            return newUnits;
        }

        public static decimal CalculateNewValue(decimal value)
        {
            decimal newValue = decimal.Parse(
                File.ReadAllText("Balance.txt")) + value;
            return newValue;
        }
    }
}
