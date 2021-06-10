using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace WebBackgroundChanger
{
    class createDir
    {
        public static string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string chrisDir = appData + @"\Chris\Downloads\";

        public static void creation()
        {
            if (!Directory.Exists(chrisDir))
            {
                Directory.CreateDirectory(chrisDir);
            }
        }
    }
}
