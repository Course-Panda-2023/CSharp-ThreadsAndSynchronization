using System;
using System.Diagnostics.Metrics;
using System.Threading;

public class SevenBoomPool
{
    static NumContainer nc;
    const int numThreads = 4;
    const int maxNum = 200;
    public static void Run()
    {
        nc = new NumContainer();
        for (int i = 0; i < numThreads; i++)
        {
            ThreadPool.QueueUserWorkItem(CountingThread, i);
        }
    }

    public static void CountingThread(object remainder)
    {
        while (true)
        {
            lock (nc)
            {
                if (nc.num >= maxNum)
                {
                    break;
                }
                if (nc.num % numThreads == (int)remainder)
                {
                    nc.num++;
                    PrintNumOrBoom(nc.num);
                }
            }
            Thread.Sleep(0);
        }
    }
    public static void PrintNumOrBoom(int num)
    {
        if (num % 7 == 0 || num.ToString().Contains('7')) { Console.WriteLine("BOOM"); }
        else Console.WriteLine(num);
    }
}
