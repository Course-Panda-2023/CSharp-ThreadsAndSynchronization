using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Management;

public class Solution
{
    public static void Assignment1Part1()
    {
        Thread printX = new Thread(new ThreadStart(PrintX));
        printX.Start();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("y");
        }
        Console.ReadLine();
    }

    public static void PrintX()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("x" + i);
        }
    }

    public static void Assignment1Part2()
    {
        Thread printX = new Thread(new ThreadStart(PrintX))
        {
            IsBackground = true
        };
        printX.Start();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("y" + i);
        }
    }

    public static void Assignment2(string str)
    {
        PrintString5Times(str);
        Thread print = new Thread(() => PrintString5Times(str));
        print.Start();
    }
    public static void PrintString5Times(string str)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(str);
        }
    }
    public static void Assignment3Part1(string str)
    {
        ThreadPool.QueueUserWorkItem(Thread1, str);
        ThreadPool.QueueUserWorkItem(Thread2);
        Console.WriteLine("Main thread");
        Thread.Sleep(1000);

        Console.WriteLine("Main thread exits.");
    }
    static void Thread1(Object str)
    {
        Console.WriteLine("hello " + str);
    }
    static void Thread2(Object doesntMatter)
    {
        Console.WriteLine("goddbye ");
    }

    public static void Assignment3Part2(string str)
    {
        int coreCount = 0;
        foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
        {
            coreCount += int.Parse(item["NumberOfCores"].ToString());
        }
        Console.WriteLine("Number Of Cores: {0}", coreCount);
        Console.WriteLine("worked: " + ThreadPool.SetMaxThreads(coreCount * 25, coreCount * 25));
    }

    public static void Assignment4Part1()
    {
        Thread print100 = new Thread(new ThreadStart(PrintHundred));
        print100.Start();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i + 1);
        }
        print100.Join();
        Console.WriteLine("joined");
    }
    public static void PrintHundred()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i + 1);
        }
        Thread.Sleep(2000);
    }
    static object printed;

    public static void Assignment4Part2()
    {
        printed = false;
        Thread print1 = new Thread(new ThreadStart(PrintHundred));
        Thread print2 = new Thread(new ThreadStart(PrintHundred));
        print1.Start();
        print2.Start();
    }
    public static void PrintHundredPart2(object obj)
    {
        lock(printed)
        {
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + 1);
            }  
        } 
    }
}
