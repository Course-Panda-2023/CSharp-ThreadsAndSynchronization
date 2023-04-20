public class Task1
{
    public Thread t1 { get; set; }
    public Thread t2 { get; set; }
    public Task1(bool backgroundrun = false)
    {
        t1 = new Thread(() => PrintX100Times());
        t2 = new Thread(() => PrintY100Times());
        if (backgroundrun)
        {
            t1.IsBackground = true;
            t2.IsBackground = true;
        } else
        {
            t1.IsBackground = false;
            t2.IsBackground = false;
        }
    }

    public void PrintX100Times()
    {
        Console.WriteLine("thread 1 starting");
        int i = 1;
        while (i <= 100)
        {
            Console.WriteLine($"x{i}");
            i++;
            Thread.Sleep(100);
        }
        Console.WriteLine("thread 1 finished");
    }

    public void PrintY100Times()
    {
        Console.WriteLine("thread 2 starting");
        int i = 1;
        while (i <= 100)
        {
            Console.WriteLine($"y{i}");
            i++;
            Thread.Sleep(100);
        }
        Console.WriteLine("thread 2 finished");
    }

    public void RunThreads()
    {
        if(t1.IsBackground == true && t2.IsBackground == true)
        {
            t1.Start();
            t2.Start();
        } else
        {
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
        Console.WriteLine("finished all threads");
    }
}