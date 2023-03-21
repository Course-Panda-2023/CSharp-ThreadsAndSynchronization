

using System.Collections;
using System.Net;
using System.Web;

/********************** 1  + 2 ****************************/

void DownloadHtmlFromWebsite()
{
    Console.WriteLine("Enter a valid url");
    string websiteUrl = Console.ReadLine();

    if (websiteUrl != null)
    {
        using (HttpClient client = new HttpClient())
        {

            Console.WriteLine("The download is executing");
            string htmlCode = client.GetStringAsync(websiteUrl).Result;
            Console.WriteLine(htmlCode);
        }
    }
}

Thread thread = new Thread(DownloadHtmlFromWebsite);
thread.Start();
thread.Join();

/********************************** 3 ******************************/
BitArray isWebsiteDone = new BitArray(3);
string[] htmlOfWebsites = new string[3];

async Task<string> DownloadHtmlFromWebsiteStringAsync()
{
    Console.WriteLine("Enter a valid URL");
    string websiteUrl = Console.ReadLine();

    if (websiteUrl != null)
    {
        using (HttpClient client = new HttpClient())
        {
            Console.WriteLine($"Downloading from {websiteUrl}...");
            string htmlCode = await client.GetStringAsync(websiteUrl);
            return htmlCode;
        }
    }

    return null;
}

Task<string> task1 = DownloadHtmlFromWebsiteStringAsync();
Task<string> task2 = DownloadHtmlFromWebsiteStringAsync();
Task<string> task3 = DownloadHtmlFromWebsiteStringAsync();

string[] results = await Task.WhenAll(task1, task2, task3);

for (int i = 0; i < results.Length; i++)
{
    htmlOfWebsites[i] = results[i];
    Console.WriteLine($"HTML code for website {i + 1}:\n{htmlOfWebsites[i]}");
}

/********************************** 4 ******************************/

string userInput = Console.ReadLine();


HttpClient client = new HttpClient();

try
{
    HttpResponseMessage response = client.GetAsync(userInput).Result;
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("The URL is valid and the website can be accessed.");
    }
    else
    {
        Console.WriteLine("The URL is not valid or the website cannot be accessed.");
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}

/*********************************** 5 **********************************/


async Task DownloadHtmlFromWebsiteAsync(CancellationToken cancellationToken)
{
    Console.WriteLine("Enter a valid URL:");
    string websiteUrl = Console.ReadLine();

    if (websiteUrl != null)
    {
        using (HttpClient client = new HttpClient())
        {
            Console.WriteLine("Downloading...");
            await Task.Delay(3000, cancellationToken); 
            cancellationToken.ThrowIfCancellationRequested();
            string htmlCode = await client.GetStringAsync(websiteUrl);
            Console.WriteLine(htmlCode);
        }
    }
}


using (CancellationTokenSource cts = new CancellationTokenSource())
{
    Task task = DownloadHtmlFromWebsiteAsync(cts.Token);

    Console.WriteLine("Press any key to cancel...");
    Console.ReadKey();

    cts.Cancel();

    try
    {
        await task;
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("The operation was canceled.");
    }
}