using System;
using System.Diagnostics.Metrics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

public class Solution
{
    static object locker;
    public static void Assignment1Part1()
    {
        Thread thread = new Thread(new ThreadStart(PrintY));
        thread.Start();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("X");
        }
    }

    public static void PrintY()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Y");
        }
    }

    public static void Assignment1Part2()
    {
        Thread thread = new Thread(new ThreadStart(PrintY)) { IsBackground = true };
        thread.Start();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("X");
        }
    }

    public static void Assignment2(string str)
    {
        Thread thread = new Thread(new ParameterizedThreadStart(PrintStr));
        thread.Start(str);
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(str);
        }
    }

    public static void PrintStr(object str)
    {
        for (int i = 0; i < 5 ;i++)
        {
            Console.WriteLine(str);
        }
    }

    public static void Assignment3Part1(string str)
    {
        ThreadPool.QueueUserWorkItem(ThreadProc, str);
        ThreadPool.QueueUserWorkItem(ThreadProc, str);
        Thread.Sleep(100);
    }

    public static void ThreadProc(object str)
    {
        Console.WriteLine(str);
    }

    public static void Assignment3Part2(string str)
    {
        Console.WriteLine($"succeeded: {ThreadPool.SetMaxThreads(GetTheAmountOfCores() * 25, GetTheAmountOfCores() * 25)}"); 
    }

    public static int GetTheAmountOfCores()
    {
        int coreCount = 0;
        foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
        {
            coreCount += int.Parse(item["NumberOfCores"].ToString());
        }
        return coreCount;
    }

    public static void Assignment4Part1()
    {
        Thread thread = new Thread(new ThreadStart(PrintNumbersPart1));
        thread.Start();
        PrintNumbersPart1();
        thread.Join();

        Thread.Sleep(2000);
        Console.WriteLine("Thread ended printing");

    }

    public static void PrintNumbersPart1()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(i);
        }
    }

    public static void Assignment4Part2()
    {
        locker = new object();
        Thread thread1 = new Thread(new ThreadStart(PrintNumbersPart2));
        Thread thread2 = new Thread(new ThreadStart(PrintNumbersPart2));
        thread1.Start();
        thread2.Start();
    }


    static void PrintNumbersPart2()
    {
        lock (locker)
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
