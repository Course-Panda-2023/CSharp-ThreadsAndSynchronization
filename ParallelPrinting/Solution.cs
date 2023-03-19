using System;

public class Solution
{
    public static void Assignment1Part1()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("X");
        }
        new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Y");
            }
        }).Start();
    }

    public static void Assignment1Part2()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("X");
        }
        Thread thread = new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Y");
            }
        })
        {
            //Thread becomes background thread
            IsBackground = true
        };
        thread.Start();
    }

    public static void Assignment2(string str)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(str);
        }
        new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(str);
            };
        }).Start();
    }

    public static void Assignment3Part1(string str)
    {
        ThreadPool.SetMaxThreads(2, 2);
        ThreadPool.QueueUserWorkItem((i) => { Console.WriteLine(str); });
        ThreadPool.QueueUserWorkItem((i) => { Console.WriteLine(str); });
    }

    public static void Assignment3Part2(string str)
    {
        int THREADS_NUMBER = 25;
        int processors = Environment.ProcessorCount;
        Console.WriteLine("The number of processors " +
        "on this computer is {0}.", processors);
        int maxThreads = processors * THREADS_NUMBER;
        // checking how many theards can run parallel
        Parallel.For(0, 10, new ParallelOptions { MaxDegreeOfParallelism = 4 }, count =>
        {
            ThreadPool.SetMaxThreads(maxThreads, count);
        });
        for (int i = 0; i <= maxThreads; i++)
            ThreadPool.QueueUserWorkItem((i) => { Console.WriteLine(str); });
    }


    public static void Assignment4Part1()
    {
        Thread thread = new Thread(() =>
        {
            for (int i = 1; i <= 100; i++)
                Console.WriteLine(i);
            Thread.Sleep(2000);
        });
        thread.Start();
        thread.Join();
        Console.WriteLine("Thread ended printing");
    }

    private static object ConsoleWriterLock = new object();

    public static void Assignment4Part2()
    {
        Thread thread1 = new Thread(() =>
        {
            lock (ConsoleWriterLock)
            {
                for (int i = 1; i <= 100; i++)
                    Console.WriteLine(i);
            }
        });
        Thread thread2 = new Thread(() =>
        {
            lock (ConsoleWriterLock)
            {
                for (int i = 1; i <= 100; i++)
                    Console.WriteLine(i);
            }
        });

        thread1.Start();
        thread2.Start();
    }
}
