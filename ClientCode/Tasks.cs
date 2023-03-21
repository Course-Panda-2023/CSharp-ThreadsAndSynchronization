using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

public class Tasks
{
    public static void Question1()
    {
        Console.WriteLine("Enter URL");
        string url = Console.ReadLine();
        Task task = new Task(() => PrintHtmlFromURL(url));
        task.Start();
        task.Wait();
    }
    public static void PrintHtmlFromURL(string url)
    {
        string htmlCode = "";
        using (WebClient client = new WebClient())
        {
            htmlCode = client.DownloadString(url);
        }
        Console.WriteLine(htmlCode);
    }
    public static void Question2() 
    {
        Console.WriteLine("Enter URL");
        string url = Console.ReadLine();
        Task task = new Task(() => PrintHtmlFromURL(url));
        task.Start();
        while (!task.IsCompleted)
        {
            Console.WriteLine("Downloading...");
            Thread.Sleep(300);
        }
        task.Wait();
    }
    public static void Question3()
    {
        Console.WriteLine("Enter 3 URLs");
        string url1 = Console.ReadLine();
        string url2 = Console.ReadLine();
        string url3 = Console.ReadLine();
        Task task1 = new Task(() => PrintHtmlFromURL(url1));
        Task task2 = new Task(() => PrintHtmlFromURL(url2));
        Task task3 = new Task(() => PrintHtmlFromURL(url3));
        task1.Start();
        task2.Start();
        task3.Start();
        task1.Wait();
        task2.Wait();
        task3.Wait();
        Console.WriteLine("All Requests Complited");
    }
    public static void Question4method1()
    {
        Console.WriteLine("Enter URL");
        string url = Console.ReadLine();
        PrintHtmlFromURLQuestion4method1(url);
    }
    public static void PrintHtmlFromURLQuestion4method1(string url)
    {
        string htmlCode = "";
        try
        {
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString(url);
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("website doesn't exist");
        }
        Console.WriteLine(htmlCode);
    }
    public static void Question4method2()
    {
        Console.WriteLine("Enter URL");
        string url = Console.ReadLine();
        AppDomain.CurrentDomain.UnhandledException += WhenExceptionDoThis;
        string htmlCode = "";
        using (WebClient client = new WebClient())
        {
            htmlCode = client.DownloadString(url);
        }
        Console.WriteLine(htmlCode);
    }
    public static void WhenExceptionDoThis(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine("Not A Website");
        Environment.Exit(0);
    }
    public static void Question5()
    {
        bool[] cancel = { false };
        Console.WriteLine("Enter URL");
        string url = Console.ReadLine();
        Task task = new Task(() => PrintHtmlFromURLQuestion5(url, cancel));
        Task cancelTask = new Task(() => ReadCancel(cancel));
        cancelTask.Start();
        task.Start();
        task.Wait();
    }
    public static void ReadCancel(bool[] cancel)
    {
        Console.WriteLine("type 'cancel' to cancel");
        string input = Console.ReadLine();
        if (input == "cancel") { cancel[0] = true; Console.WriteLine("operation cancled"); }
        else ReadCancel(cancel);
    }
    public static void PrintHtmlFromURLQuestion5(string url, bool[] cancel)
    {
        string htmlCode = "";
        using (WebClient client = new WebClient())
        {
            htmlCode = client.DownloadString(url);
        }
        for (int i = 0;i < 10; i++) 
        {
            Thread.Sleep(300);
            if (cancel[0]) { Environment.Exit(0); }
        }
        Console.WriteLine(htmlCode);
    }
}
