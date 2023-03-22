using System;
using Microsoft.VisualBasic;


public class SevenBoom
{
    static NumContainer nc;
    const int maxNum = 200;
    public static void Run() 
    { 
        nc = new NumContainer();
        Thread thread0 = new Thread(() => CountingThread(0));
        thread0.Start();
        Thread thread1 = new Thread(() => CountingThread(1));
        thread1.Start();
        Thread thread2 = new Thread(() => CountingThread(2));
        thread2.Start();
        Thread thread3 = new Thread(() => CountingThread(3));
        thread3.Start();
    }

    public static void CountingThread(int remainder)
    {
        while (true)
        {    
            lock(nc)
            {
                if (nc.num >= maxNum)
                {
                    break;
                }
                if (nc.num%4 == remainder)
                {
                    nc.num++;
                    Console.WriteLine(NumOrBoom(nc.num));
                }
            }
            Thread.Sleep(0);
        }
    }
    public static string NumOrBoom(int num)
    {
        if (num % 7 == 0 || num.ToString().Contains('7')) { return "BOOM"; }
        else return num.ToString();
    }
        
}

