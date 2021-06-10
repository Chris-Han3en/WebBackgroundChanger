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
    class Program
    {
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        static void Main(string[] args)
        {
            NativeMethods.AllocConsole();
            Console.Title = "Background Changer";
            Intro.start();
        }
    }
}
