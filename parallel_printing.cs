// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Assignment1()
    {

        // create a new thread
        Thread BackgroundThread = new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("X");
            };
        });
        BackgroundThread.IsBackground = true;

        // start the thread
        BackgroundThread.Start();

        // do some other work in the main thread
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Y");
        }

    }

    //________________________________________________

    static void Assignment2(string str_A2)
    {
        // create a new thread
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(str_A2);
            };
        });


        // start the thread
        thread2.Start();

        // printing in the main thread
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(str_A2);
        }

    }

    static void Assignment3()
    {
        int cores = Environment.ProcessorCount;
        //Console.WriteLine(cores);
        int threadNum = 25 * cores;
        ThreadPool.SetMaxThreads(threadNum,0);
        ThreadPool.QueueUserWorkItem(new WaitCallback(x => Console.WriteLine("tamir")));
        ThreadPool.QueueUserWorkItem(new WaitCallback(x => Console.WriteLine("Tamir")));
        Thread.Sleep(100);
    }
    static void Assignment4_part1()
    {
        // create a new thread
        Thread thread4 = new Thread(() =>
        {
            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(i);
            };
        });
        thread4.Start();
        thread4.Join();
        Thread.Sleep(2000);
        Console.WriteLine("Thread ended printing");
    }
    static void Assignment4_part2()
    {
        object threadLock = new object();
        void print_nums()
        {
            lock (threadLock)
            {
                for (int i = 1; i < 101; i++)
                {
                    Console.WriteLine(i);
                };
            }
        }
        Thread thread4_1 = new Thread(print_nums);
        Thread thread4_2 = new Thread(print_nums);

        thread4_1.Start();
        thread4_2.Start();
        thread4_1.Join();
        thread4_2.Join();
    }
    private static void Main()
    {
        Assignment4_part2();
    }
}