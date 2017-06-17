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
            Console.Clear(); //Clear for each iteration of loop

            int inputUnits; //Input variable to store units bought/sold in Menu navigation switch
            decimal inputValue; //Input variable to store balance change in Menu navigation switch

            //Begin Menu navigation
            MenuText();
            string result = Console.ReadLine();
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
                    inputUnits = int.Parse(Console.ReadLine());
                    Console.Write("Enter purchase price: $");
                    inputValue = decimal.Parse(Console.ReadLine()) * -1;
                    Console.Clear();
                    FileData.ReadInventoryFile();
                    SavePrompt(inputUnits, inputValue);
                    break;
                case "3": //Sell Prompt
                    Console.Clear();
                    Console.WriteLine("Sell Items\n");
                    Console.Write("Enter units sold: ");
                    inputUnits = int.Parse(Console.ReadLine()) * -1;
                    Console.Write("Enter sale price: $");
                    inputValue = decimal.Parse(Console.ReadLine());
                    Console.Clear();
                    FileData.ReadInventoryFile();
                    SavePrompt(inputUnits, inputValue);
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
        
        public static void SavePrompt(int inputUnits, decimal inputValue)
        {
            int newUnits = Calculate.CalculateNewUnits(inputUnits);
            decimal newValue = Calculate.CalculateNewValue(inputValue);
            Console.WriteLine("Updated units owned: {0}", newUnits);
            Console.WriteLine("Updated balance: {0:C}", newValue);
            Console.WriteLine();
            Console.WriteLine("Save changes? Y or N");
            string saveResult = Console.ReadLine().ToUpper();

            if (saveResult == "Y")
            {
                //Extra save step, not absolutely neccesary. Extra practice with a nested loop
                Console.WriteLine("Are you sure? Y or N");
                string sureResult = Console.ReadLine().ToUpper();
                if (sureResult == "Y")
                {
                    FileData.SaveData(newUnits, newValue);
                    Console.WriteLine("Saved!");
                    Console.ReadLine();
                }
                else if (sureResult == "N")
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
            else if (saveResult == "N")
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
            Console.WriteLine("Y or N: ");
            string saveResult = Console.ReadLine().ToUpper();
            if (saveResult == "Y")
            {
                //Extra save step, not absolutely neccesary. Extra practice with a nested loop
                Console.WriteLine("Are you sure? Y or N");
                string sureResult = Console.ReadLine().ToUpper();
                if (sureResult == "Y")
                {
                    FileData.SaveData(0, 0);
                    Console.WriteLine("\nData reset.");
                    Console.ReadLine();
                }
                else if (sureResult == "N")
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
            else if (saveResult == "N")
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
