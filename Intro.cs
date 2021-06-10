using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace WebBackgroundChanger
{
    class Intro
    {
        public static void start()
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("Welcome to background changer!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Please select an option.\n");
            Thread.Sleep(500);
            Console.WriteLine("1. Start Search.");
            Console.WriteLine("2. Instructions.");
            Console.WriteLine("3. Quit.\n");
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("An error has occured. Please follow the instructions.\nPlease press any key to continue.");
                Console.ReadKey();
                start();
            }
            if (option == 1)
            {
                Console.Clear();
                Searcher.search();
            }
            else if (option == 2)
            {
                Console.Clear();
                Console.WriteLine("When prompted, just enter in the search topic and the program search and download accordingly and then change the background.");
                Thread.Sleep(2000);
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                start();
            }
            else if (option == 3)
            {
                Console.WriteLine("Thank you for using my service.");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please pick one of the options from the menu.\nPress any key to continue.");
                Console.ReadKey();
                start();
            }
        }
    }
}
