using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddy
    //Simple purchase/sales tracking using menu navigation and files
    //Assumes only whole (int) dollar amounts, not decimal
{
    //Change 'units'
    class Program
    {
        static void Main()
        {
            FileCheck();
            bool displayMenu = true;
            while (displayMenu == true)
            {
                displayMenu = MainMenu();
            }

    }
        private static void FileCheck()
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

        private static bool MainMenu()
        {
            Console.Clear();
            MenuText();
            string result = Console.ReadLine();
            if (result == "1")
            {
                Console.Clear();
                Console.WriteLine("Overview\n");
                ReadInventoryFile();
                Console.ReadLine();
                return true;
            }
            else if (result == "2")
            {
                Console.Clear();
                Console.WriteLine("Buy Items\n");
                Console.Write("Enter units purchased: ");
                int inputAmount = Int32.Parse(Console.ReadLine());
                Console.Write("Enter purchase price: $");
                int inputPrice = Int32.Parse(Console.ReadLine()) * -1;
                Console.Clear();
                ReadInventoryFile();
                int newAmount = CalculateNewAmount(inputAmount);
                int newPrice = CalculateNewPrice(inputPrice);
                Console.WriteLine("Updated units owned: {0}", newAmount);
                Console.WriteLine("Updated balance: {0:C}", newPrice);
                Console.ReadLine();
                Console.WriteLine("Save changes? Y or N");
                string saveResult = Console.ReadLine();
                if (saveResult == "Y" || saveResult == "y")
                {
                    Console.WriteLine("Are you sure? Y or N");
                    string sureResult = Console.ReadLine();
                    if (sureResult == "Y" || sureResult == "y")
                    {
                        SaveData(newAmount, newPrice);
                        Console.WriteLine("Saved!");
                        Console.ReadLine();
                    }
                    else if (sureResult == "N" || sureResult == "n")
                    {
                        Console.WriteLine("\nAmount not saved.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nCommand not recognized.");
                        Console.ReadLine();
                    }

                }
                else if (saveResult == "N" || saveResult == "n")
                {
                    Console.WriteLine("\nAmount not saved.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nCommand not recognized.");
                    Console.ReadLine();
                }

                return true;
            }
            else if (result == "3")
            {
                Console.Clear();
                Console.WriteLine("Sell Items\n");
                Console.Write("Enter units sold: ");
                int inputAmount = Int32.Parse(Console.ReadLine()) * -1;
                Console.Write("Enter sale price: $");
                int inputPrice = Int32.Parse(Console.ReadLine());
                Console.Clear();
                ReadInventoryFile();
                int newAmount = CalculateNewAmount(inputAmount);
                int newPrice = CalculateNewPrice(inputPrice);
                Console.WriteLine("Updated units owned: {0}", newAmount);
                Console.WriteLine("Updated balance: {0:C}", newPrice);
                Console.ReadLine();
                Console.WriteLine("Save changes? Y or N");
                string saveResult = Console.ReadLine();
                if (saveResult == "Y" || saveResult == "y")
                {
                    Console.WriteLine("Are you sure? Y or N");
                    string sureResult = Console.ReadLine();
                    if (sureResult == "Y" || sureResult == "y")
                    {
                        SaveData(newAmount, newPrice);
                        Console.WriteLine("Saved!");
                        Console.ReadLine();
                    }
                    else if (sureResult == "N" || sureResult == "n")
                    {
                        Console.WriteLine("\nAmount not saved.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nCommand not recognized.");
                        Console.ReadLine();
                    }

                }
                else if (saveResult == "N" || saveResult == "n")
                {
                    Console.WriteLine("\nAmount not saved.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nCommand not recognized.");
                    Console.ReadLine();
                }
                return true;
            }
            else if (result == "4")
            {
                Console.Clear();
                Console.WriteLine("Reset inventory data? Y or N");
                string saveResult = Console.ReadLine();
                if (saveResult == "Y" || saveResult == "y")
                {
                    Console.WriteLine("Are you sure? Y or N");
                    string sureResult = Console.ReadLine();
                    if (sureResult == "Y" || sureResult == "y")
                    {
                        SaveData(0, 0);
                        Console.WriteLine("\nData reset.");
                        Console.ReadLine();
                    }
                    else if (sureResult == "N" || sureResult == "n")
                    {
                        Console.WriteLine("\nAmount not saved.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nCommand not recognized.");
                        Console.ReadLine();
                    }

                }
                else if (saveResult == "N" || saveResult == "n")
                {
                    Console.WriteLine("\nAmount not saved.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nCommand not recognized.");
                    Console.ReadLine();
                }
                return true;
            }
            else if (result == "5")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Command not recognized");
                Console.ReadLine();
                return true;
            }
        }
        private static void MenuText()
        {
            Console.WriteLine("---Buddy---\n");
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Overview");
            Console.WriteLine("2. Buy");
            Console.WriteLine("3. Sell");
            Console.WriteLine("4. Reset Data");
            Console.WriteLine("5. Exit\n");
        }

        private static void ReadInventoryFile()
        {
            string amount = File.ReadAllText("Amount.txt");
            string bal = File.ReadAllText("Price.txt");
            Console.WriteLine("Standing units owned: {0}", amount);
            Console.WriteLine("Standing balance: {0:C}", bal);
        }

        private static int CalculateNewAmount(int amount)
        {
            int newAmount = Int32.Parse(
                File.ReadAllText(
                    "Amount.txt")) 
                    + amount;
            return newAmount;
        }

        private static int CalculateNewPrice(int price)
        {
            int newPrice = Int32.Parse(
                File.ReadAllText(
                    "Price.txt"))
                    + price;
            return newPrice;
        }

        private static void SaveData(int saveAmount, int savePrice)
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
