using System;

namespace BuddyRework
{
    class Menu
    {
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

        public static void MainMenu()
        {
            Console.Clear();
            MenuText();
            string result = Console.ReadLine();
            int inputAmount;
            decimal inputPrice;

            //Menu navigation
            switch (result)
            {
                case "1": //Overview
                    Console.Clear();
                    Console.WriteLine("Overview\n");
                    FileData.ReadInventoryFile();
                    Console.ReadLine();
                    break;
                case "2": //Buy Prompt
                    Console.Clear();
                    Console.WriteLine("Buy Items\n");
                    Console.Write("Enter units purchased: ");
                    inputAmount = int.Parse(Console.ReadLine());
                    Console.Write("Enter purchase price: $");
                    inputPrice = decimal.Parse(Console.ReadLine()) * -1;
                    Console.Clear();
                    FileData.ReadInventoryFile();
                    SavePrompt(inputAmount, inputPrice);
                    break;
                case "3": //Sell Prompt
                    Console.Clear();
                    Console.WriteLine("Sell Items\n");
                    Console.Write("Enter units sold: ");
                    inputAmount = int.Parse(Console.ReadLine()) * -1;
                    Console.Write("Enter sale price: $");
                    inputPrice = decimal.Parse(Console.ReadLine());
                    Console.Clear();
                    FileData.ReadInventoryFile();
                    SavePrompt(inputAmount, inputPrice);
                    break;
                case "4": //Reset Prompt
                    ResetPrompt();
                    break;
                case "5": //Exit
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Command not recognized");
                    Console.ReadLine();
                    break;
            }
        }

        public static void SavePrompt(int inputAmount, decimal inputPrice)
        {
            int newAmount = Calculate.CalculateNewAmount(inputAmount);
            decimal newPrice = Calculate.CalculateNewPrice(inputPrice);
            Console.WriteLine("Updated units owned: {0}", newAmount);
            Console.WriteLine("Updated balance: {0:C}", newPrice);
            Console.WriteLine();
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
        }

        public static void ResetPrompt()
        {
            Console.Clear();
            Console.WriteLine("Reset inventory data? This cannot be undone.");
            Console.Write("Y or N: ");
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
                    Console.WriteLine("\nData not reset.");
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
                Console.WriteLine("\nData not reset.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nCommand not recognized.");
                Console.ReadLine();
            }
        }
        
    }
}
