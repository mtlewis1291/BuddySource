﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyRework
//Simple purchase/sales tracking using menu navigation and 2 separate files for storing units and balance
{
    class Program
    {
        static void Main()
        {
            FileData.FileCheck();
            while(true)
            {
                Menu.MainMenu();
            }
        }
    }
}
