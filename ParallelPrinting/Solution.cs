using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Solution
{
    static object locker;
    public static void PrintX()
    {
        for (int i = 0; i < 100; i++)
            Console.WriteLine("X");
    }
    public static void PrintY()
    {
        for (int i = 0; i < 100; i++)
            Console.WriteLine("Y");
    }
    public static void PrintString(object s)
    {
        for (int i = 0; i < 5; i++)
            Console.WriteLine(s);
    }
    public static void ThreadFunction(object s)
    {
        Console.WriteLine(s);
    }
    public static void Assignment1Part1()
    {
        Thread t = new Thread(new ThreadStart(PrintX));
        t.Start();
        PrintY();
    }
    public static void Assignment1Part2()
    {
        Thread t = new Thread(new ThreadStart(PrintX)) { IsBackground = true };
        t.Start();
        PrintY();
    }
    public static void Assignment2(string str)
    {
        Thread t = new Thread(new ParameterizedThreadStart(PrintString));
        t.Start(str);
        PrintString(str);
    }
    public static void Assignment3Part1(string str)
    {
        ThreadPool.QueueUserWorkItem(ThreadFunction, str);
        ThreadPool.QueueUserWorkItem(ThreadFunction, str);
        Thread.Sleep(1000);
    }
    public static void Assignment3Part2()
    {
        Console.WriteLine($"succeeded: {ThreadPool.SetMaxThreads(Environment.ProcessorCount * 25, Environment.ProcessorCount * 25)}");
    }
    public static void PrintNumbersOneToHundred()
    {
        for (int i = 1; i <= 100; i++)
            Console.WriteLine(i);
    }
    public static void PrintNumbersOneToHundredWithLock()
    {
        lock (locker)
        {
            PrintNumbersOneToHundred();
        }
    }
    public static void Assignment4Part1()
    {
        Thread t = new Thread(new ThreadStart(PrintNumbersOneToHundred));
        t.Start();
        PrintNumbersOneToHundred();
        t.Join();
        Thread.Sleep(2000);
        Console.WriteLine("Thread Ended Printing");
    }
    public static void Assignment4Part2()
    {
        locker = new object();
        Thread thread1 = new Thread(new ThreadStart(PrintNumbersOneToHundredWithLock));
        Thread thread2 = new Thread(new ThreadStart(PrintNumbersOneToHundredWithLock));
        thread1.Start();
        thread2.Start();
    }
}