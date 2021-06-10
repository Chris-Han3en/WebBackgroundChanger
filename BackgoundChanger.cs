using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Net;
using System.IO.Compression;

namespace WebBackgroundChanger
{
    class BackgoundChanger
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);
        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;

        public static void changer()
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, createDir.chrisDir + "image.png", SPIF_UPDATEINIFILE);
        }
    }
}
