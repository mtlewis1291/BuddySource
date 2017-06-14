using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyRework
//Simple purchase/sales tracking using menu navigation and files
//Assumes only whole (int) dollar amounts, not decimal
{
    class Program
    {
        static void Main()
        {
            FileData.FileCheck();
            bool displayMenu = true;
            while (displayMenu == true)
            {
                displayMenu = Menu.MainMenu();
            }

        }
    }
}
