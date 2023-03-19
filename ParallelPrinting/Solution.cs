using System;
using System.Net.WebSockets;

public class Solution
{       
    delegate void Print(string s,int num);
    delegate void Print5(object s);


    static Print printString = delegate (string s,int num)
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine(s + " , " + i);
        }
    };

    static Print5 print5String = delegate (object s)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine((string)s + " , " + i);
        }
    };




    public static void Assignment1Part1()
    {

        Thread X = new Thread(() => printString("X",100));

        Thread Y = new Thread(() => printString("Y",100));

        Console.WriteLine("Y - " + Y.IsBackground);

        Console.WriteLine("X - " + X.IsBackground);

        X.Start();
        Y.Start();


    }

    public static void Assignment1Part2()
    {
        Thread X = new Thread(() => printString("X", 100)) { IsBackground = true };


        Thread Y = new Thread(() => printString("Y", 100)) { IsBackground = true };


        Console.WriteLine("Y - " + Y.IsBackground);

        Console.WriteLine("X - " + X.IsBackground);

        X.Start();
        Y.Start();
    }

    public static void Assignment2(string str)
    {
        Thread t1= new Thread(new ParameterizedThreadStart(print5String));
        Thread t2= new Thread(new ParameterizedThreadStart(print5String));

        t1.Start(str);
        t2.Start(str);

    }

    public static void Assignment3Part1(string str)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(print5String), str);
        ThreadPool.QueueUserWorkItem(new WaitCallback(print5String), str);

    }

    public static void Assignment3Part2(string str)
    {
        int max = 25 * Environment.ProcessorCount;
        ThreadPool.SetMaxThreads(max, max);

        ThreadPool.QueueUserWorkItem(new WaitCallback(print5String), str);
        ThreadPool.QueueUserWorkItem(new WaitCallback(print5String), str);
    }

    public static void Assignment4Part1()
    {
        Thread t1 = new Thread(() => { for (int i = 1; i <= 100; i++) Console.WriteLine(i); });
        t1.Start();

        t1.Join();
        Thread.Sleep(2000);
        Console.WriteLine("Thread ended printing");
    }

    public static void Assignment4Part2()
    {
        object lockKey = new object();
        Thread t1 = new Thread(() => 
        {
            for (int i = 1; i <= 50 ; i++)
                lock (lockKey)
                {
                    Console.WriteLine(i); 
                }
        });

        Thread t2 = new Thread(() => 
        {
            for (int i = 51; i <= 100; i++)
                lock (lockKey)
                {
                    Console.WriteLine(i);
                }
        });
        t1.Start();
        t2.Start();        
        


    }
}
