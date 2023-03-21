using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;

namespace ClientCode
{
    public class Tasks
    {

        public void Assignment1()
        {
            Console.WriteLine("Enter the URL of a website you want the html of.");
            string siteURL = Console.ReadLine();
            Task task = new Task(() => PrintHTML(siteURL));
            task.Start();
            task.Wait();
        }

        public void PrintHTML(string siteURL)
        {
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString(siteURL);
            }
            Console.WriteLine(htmlCode);
        }

        public void Assignment2()
        {
            bool printed = false;
            Console.WriteLine("Enter the URL of a website you want the html of.");
            string siteURL = Console.ReadLine();
            Task task = new Task(() => PrintHTML(siteURL));
            task.Start();
            while(!task.IsCompleted && !printed)
            {
                Console.WriteLine("The wanted HTML is downloading...");
                printed = true;
            }
            task.Wait();
        }

        public void Assignment3()
        {
            Console.WriteLine("Enter the URL of 3 websites you want the html of.");
            string site1URL = Console.ReadLine();
            string site2URL = Console.ReadLine();
            string site3URL = Console.ReadLine();
            Task task1 = new Task(() => PrintHTML(site1URL));
            Task task2 = new Task(() => PrintHTML(site2URL));
            Task task3 = new Task(() => PrintHTML(site3URL));
            task1.Start();
            task2.Start();
            task3.Start();
            task1.Wait();
            task2.Wait();
            task3.Wait();
            Console.WriteLine("All requests received");
        }

        public void Assignment4Part1()
        {
            Console.WriteLine("Enter the URL of a website you want the html of.");
            string siteURL = Console.ReadLine();
            string htmlCode = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    htmlCode = client.DownloadString(siteURL);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Website does not exist.");
            }
            Console.WriteLine(htmlCode);
        }

        public void Assignment4Part2()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Console.WriteLine("Enter the URL of a website you want the html of.");
            string siteURL = Console.ReadLine();
            string htmlCode = "";
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString(siteURL);
            }
            Console.WriteLine(htmlCode);
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Website does not exist.");
            Environment.Exit(1);
        }

        public void Assignment5()
        {
            Console.WriteLine("Enter the URL of a website you want the html of.");
            string siteURL = Console.ReadLine();
            Task task = new Task(() => PrintHTML_5(siteURL));
            task.Start();
            string cancel = Console.ReadLine();
            ThreadPool.QueueUserWorkItem(cancelMethod, cancel);
            task.Wait();
        }

        public void PrintHTML_5(string siteURL)
        {
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString(siteURL);
            }
            Thread.Sleep(3000);
            Console.WriteLine(htmlCode);
        }
        public void cancelMethod(object cancel)
        {
            if(cancel.ToString() == "Cancel")
            {
                Environment.Exit(1);
            }
        }
    }
}
