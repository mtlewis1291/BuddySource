using System;
using System.IO;


namespace BuddyRework
{
    class FileData
    {
        public static void FileCheck()
        {
            string amountPath = "Amount.txt";
            if (!File.Exists(amountPath))
            {
                File.WriteAllText(amountPath, "0");
            }

            string pricePath = "Price.txt";
            if (!File.Exists(pricePath))
            {
                File.WriteAllText(pricePath, "0");
            }
        }

        public static void ReadInventoryFile()
        {
            string amount = File.ReadAllText("Amount.txt");
            string bal = File.ReadAllText("Price.txt");
            Console.WriteLine("Standing units owned: {0}", int.Parse(amount));
            Console.WriteLine("Standing balance: {0:C}", decimal.Parse(bal));
        }

        public static void SaveData(int saveAmount, decimal savePrice)
        {
            using (StreamWriter file = new StreamWriter("Amount.txt", false))
            {
                file.WriteLine(saveAmount.ToString());
            }
            using (StreamWriter file = new StreamWriter("Price.txt", false))
            {
                file.WriteLine(savePrice.ToString());
            }
        }
    }
}
