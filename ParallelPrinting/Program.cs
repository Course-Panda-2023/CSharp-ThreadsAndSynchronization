using System;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        Thread t1 = new Thread(new ParameterizedThreadStart(CountTo100ByThread));
        Thread t2 = new Thread(new ParameterizedThreadStart(CountTo100ByThread));

        t1.Start(Tuple.Create("thread 1", t2));
        t2.Start(Tuple.Create("thread 2", t1));

        t1.Join();
        t2.Join();

        Thread.Sleep(2000);
        Console.WriteLine("all threads finished");
    }d

    public static void CountTo100ByThread(object param)
    {
        var parameters = (Tuple<string, Thread>)param;
        string threadname = parameters.Item1;
        object threadToLock = parameters.Item2;

        lock (threadToLock)
        {
            Thread.CurrentThread.Name = threadname;
            Console.WriteLine($"{threadname} starting");
            int i = 1;
            while (i <= 100)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                i++;
                Thread.Sleep(100);
            }
            Console.WriteLine($"{threadname} finishing");
        }
    }
}
