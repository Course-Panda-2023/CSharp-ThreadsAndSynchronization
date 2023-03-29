using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;


public class Solution
{
    public static void Assignment1Part1(bool IsBackground = false)
    {
        const char x = 'X';
        const char y = 'Y';
        const int numOfTimes = 100;

        Thread t = new Thread(() => AssignmentFunctions.PrintChar(y, numOfTimes))
        {
            Name = "Thread"
        };
        
        t.IsBackground = IsBackground;
        t.Start();

        AssignmentFunctions.PrintChar(x, numOfTimes);
        Console.WriteLine("Main Thread Ended");
    }

    public static void Assignment1Part2()
    {
        Assignment1Part1(true);
    }

    public static void Assignment2(string str)
    {
        // isn't it like I did with 1, in terms of parameter passing?
    }

    public static void Assignment3Part1(string str)
    {
        for (int i = 0; i < 2; i++)
        {
            ThreadPool.QueueUserWorkItem(AssignmentFunctions.PrintStr, new object [] {str});
        }
        Console.Read();
    }

    public static void Assignment3Part2(string str)
    {
        int MaxThreads = Environment.ProcessorCount*25;
        ThreadPool.SetMaxThreads(MaxThreads, MaxThreads);
    }

    public static void Assignment4Part1()
    {
        Thread thread = new Thread(AssignmentFunctions.PrintNumbers);
        thread.Start();

        thread.Join();
        Thread.Sleep(2000);
        Console.WriteLine("Finished printing");
    }

    public static void Assignment4Part2()
    {
        Thread[] mythread = new Thread[2];
        for (int Op = 0; Op < 2; Op++)
        {
            mythread[Op] = new Thread(new ThreadStart(AssignmentFunctions.Values));
            mythread[Op].Name = " " + Op;
        }
        foreach (Thread td in mythread)
            td.Start();
    }
}
