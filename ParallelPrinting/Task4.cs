public class Task4
{
    public Task4()
    {

    }
    public void CountTo100WithLock(object param)
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

    public void CountTo100ByThread(string threadname)
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


    public void RunThreadsWithLocking()
    {
        Thread t1 = new Thread(new ParameterizedThreadStart(CountTo100WithLock));
        Thread t2 = new Thread(new ParameterizedThreadStart(CountTo100WithLock));

        t1.Start(Tuple.Create("thread 1", t2));
        t2.Start(Tuple.Create("thread 2", t1));

        t1.Join();
        t2.Join();

        Thread.Sleep(2000);
        Console.WriteLine("all threads finished");
    }    
    public void RunThreads()
    {
        Thread t1 = new Thread(() =>
        {
            CountTo100ByThread("thread 1");
        });

        Thread t2 = new Thread(() =>
        {
            CountTo100ByThread("thread 2");
        });

        t1.Start(); // start the first thread first
        t2.Start();

        t1.Join();
        t2.Join();

        Thread.Sleep(2000);
        Console.WriteLine("all threads finished");
    }
}