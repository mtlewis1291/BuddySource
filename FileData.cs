using System;
using System.IO;


namespace BuddyRework
{
    class FileData
    {
        public static void FileCheck()
        {
            string inventoryPath = "Inventory.txt";
            if (!File.Exists(inventoryPath))
            {
                File.WriteAllText(inventoryPath, "0");
            }

            string balancePath = "Balance.txt";
            if (!File.Exists(balancePath))
            {
                File.WriteAllText(balancePath, "0");
            }
        }

        public static void ReadInventoryFile()
        {
            string units = File.ReadAllText("Inventory.txt");
            string value = File.ReadAllText("Balance.txt");
            Console.WriteLine("Standing units owned: {0}", int.Parse(units));
            Console.WriteLine("Standing balance: {0:C}", decimal.Parse(value));
        }

        public static void SaveData(int saveUnits, decimal saveValue)
        {
            using (StreamWriter file = new StreamWriter("Inventory.txt", false))
            {
                file.WriteLine(saveUnits.ToString());
            }
            using (StreamWriter file = new StreamWriter("Balance.txt", false))
            {
                file.WriteLine(saveValue.ToString());
            }
        }
    }
}
