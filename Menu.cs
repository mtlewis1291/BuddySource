using System;

namespace BuddyRework
{
    class Menu
    {
        public static bool MainMenu()
        {
            Console.Clear();
            MenuText();
            string result = Console.ReadLine();
            if (result == "1")
            {
                Console.Clear();
                Console.WriteLine("Overview\n");
                FileData.ReadInventoryFile();
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
                FileData.ReadInventoryFile();
                int newAmount = Calculate.CalculateNewAmount(inputAmount);
                int newPrice = Calculate.CalculateNewPrice(inputPrice);
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
                        FileData.SaveData(newAmount, newPrice);
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
                FileData.ReadInventoryFile();
                int newAmount = Calculate.CalculateNewAmount(inputAmount);
                int newPrice = Calculate.CalculateNewPrice(inputPrice);
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
                        FileData.SaveData(newAmount, newPrice);
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
                        FileData.SaveData(0, 0);
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

        public static void MenuText()
        {
            Console.WriteLine("---Buddy---\n");
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Overview");
            Console.WriteLine("2. Buy");
            Console.WriteLine("3. Sell");
            Console.WriteLine("4. Reset Data");
            Console.WriteLine("5. Exit\n");
        }
    }
}
