using System;

public class SevenBoomBonus
{
    static private NumContainer nc;
    const int timeConst = 100;
    const int numThreads = 4;
    const int maxNum = 200;
    public static void Run()
    {
        nc = new NumContainer();
        for (int i = 0; i < numThreads; i++)
        {
            ThreadPool.QueueUserWorkItem(CountingThread, i);
            Thread.Sleep(timeConst);
        }
    }

    public static void CountingThread(object ThreadId)
    {
        while (true)
        {
            if (nc.num >= maxNum)
            {
                break;
            }
            Console.Write("Thread " + ThreadId + ": ");
            nc.num++;
            PrintNumOrBoom(nc.num);
            Thread.Sleep(timeConst * numThreads);
        }
    }
    public static void PrintNumOrBoom(int num)
    {
        if (num % 7 == 0 || num.ToString().Contains('7')) { Console.WriteLine("BOOM"); }
        else Console.WriteLine(num);
    }
}