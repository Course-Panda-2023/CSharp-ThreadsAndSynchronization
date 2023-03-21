using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        DownloadWebsiteHTMLT5();
    }

    public static void DownloadWebsiteHTMLT1()
    {
        Console.Write("Enter website address: ");
        string website = Console.ReadLine();

        using (WebClient client = new WebClient())
        {
            string html = client.DownloadString(website);
            Console.WriteLine(html);
        }
    }

    public static void DownloadWebsiteHTMLT2()
    {
        Console.Write("Enter website address: ");
        string website = Console.ReadLine();

        Console.WriteLine("Downloading in progress...");

        using (WebClient client = new WebClient())
        {
            string html = client.DownloadString(website);
            Console.WriteLine(html);
        }
    }

    public static void DownloadWebsiteHTMLT3()
    {
        Console.Write("Enter first website address: ");
        string website1 = Console.ReadLine();
        Console.Write("Enter second website address: ");
        string website2 = Console.ReadLine();
        Console.Write("Enter third website address: ");
        string website3 = Console.ReadLine();

        using (WebClient client = new WebClient())
        {
            string html1 = client.DownloadString(website1);
            string html2 = client.DownloadString(website2);
            string html3 = client.DownloadString(website3);

            Console.WriteLine(html1);
            Console.WriteLine(html2);
            Console.WriteLine(html3);

            Console.WriteLine("All downloads finished.");
        }
    }

    public static void DownloadWebsiteHTMLT4()
    {
        Console.Write("Enter website address: ");
        string website = Console.ReadLine();

        Console.WriteLine("Downloading in progress...");
        try
        {
            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(website);
                if (!string.IsNullOrEmpty(html)) // Check if website exists
                {
                    Console.WriteLine(html);
                    Console.WriteLine("Download finished");
                }
                else
                {
                    Console.WriteLine("Website does not exist or is not accessible");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error downloading website HTML: " + ex.Message);
        }
    }

    public static void DownloadWebsiteHTMLT5()
    {
        Console.Write("Enter website address: ");
        string website = Console.ReadLine();

        using (WebClient client = new WebClient())
        {
            var cts = new CancellationTokenSource();
            Console.WriteLine("Type 'cancel' to cancel.");
            var task = Task.Run(() =>
            {
                try
                {
                    var html = client.DownloadString(website);
                    Thread.Sleep(3000);
                    Console.WriteLine(html);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }, cts.Token);

            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "cancel")
                {
                    cts.Cancel();
                    Console.WriteLine("cancelled");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Type 'cancel' to cancel.");
                }
            }

            task.Wait();
        }
    }

}

