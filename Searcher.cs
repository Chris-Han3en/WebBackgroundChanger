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
    class Searcher
    {
        public static void search()
        {
            createDir.creation();//creates appdata dir for storing images
            string[] urls =
            {
                "",
                "",
                "",
                "",
                ""
            };
            int i = 0;
            string response = string.Empty;
            string url = "https://www.google.com/search?q=";
            string imageUrl = "&source=lnms&tbm=isch&sa=X";
            Console.Clear();
            Console.WriteLine("Please enter what you want to search for:\n");
            try
            {
                response = Console.ReadLine();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("An error has occured. Please follow the instructions.\nPlease press any key to continue.");
                Console.ReadKey();
                search();
            }
            string[] responseWords = response.Split(' ');

            try
            {
                foreach (string arg in responseWords)
                {
                    urls[i] = arg;
                    i++;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Please only enter a maximum of 5 words for the search.\nPress any key to continue.");
                Console.ReadKey();
                search();
            }

            url = url + urls[0] + "+" + urls[1] + "+" + urls[2] + "+" + urls[3] + "+" + urls[4] + imageUrl;

            Console.WriteLine(url);
            var t = new Thread(getUrl);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            void getUrl()
            {
                WebBrowser browser1 = new WebBrowser();
                browser1.Navigate(url);
                browser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(downloader);
                MessageBox.Show($"'{response}' chosen. Please wait.");

                void downloader(object sender, WebBrowserDocumentCompletedEventArgs e)
                {
                    HtmlElementCollection collection;
                    List<HtmlElement> imgListString = new List<HtmlElement>();

                    if (browser1 != null)
                    {
                        if (browser1.Document != null)
                        {
                            collection = browser1.Document.GetElementsByTagName("img");
                            if (collection != null)
                            {
                                using (var client = new WebClient())
                                {
                                    ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => {
                                        return true;
                                    };
                                    string byteDownload = collection[0].GetAttribute("src");
                                    string output = createDir.chrisDir + "image.png";
                                    byteDownload = byteDownload.Replace("data:image/jpeg;base64,", "");
                                    if (byteDownload != null && byteDownload.Length != 0)
                                    {
                                        SaveByteArrayAsImage(output, byteDownload);

                                        void SaveByteArrayAsImage(string fullOutputPath, string base64String)
                                        {
                                            byte[] bytes = Convert.FromBase64String(base64String);

                                            Image image;
                                            using (MemoryStream ms = new MemoryStream(bytes))
                                            {
                                                try
                                                {
                                                    image = Image.FromStream(ms);
                                                    image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Png);
                                                    Thread.Sleep(1000);
                                                    BackgoundChanger.changer();
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(e);
                                                    Console.WriteLine("This error occured as you entered in the wrong format once and tried again and a error occured\nPlease reload the software and try again.\nPress any key to continue.");
                                                    Console.ReadKey();
                                                    Environment.Exit(1);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("collection null");
                            }
                        }
                        else
                        {
                            MessageBox.Show("document null");
                        }
                    }
                    else
                    {
                        MessageBox.Show("null");
                    }
                }
            }
        }
    }
}
