public class Task3
{
    public Task3()
    {

    }
    public void PrintSomething(object obj)
    {
        string something = (string)obj;
        Console.WriteLine($"something {something}");
        Thread.Sleep(new Random().Next(1000, 5000));
        Console.WriteLine($"goodbye {something}");
    }

    public void RunAllThreadsByCPU(object obj)
    {
        int coreCount = Environment.ProcessorCount;
        int MaxThreads = coreCount * 25;
        ThreadPool.SetMaxThreads(MaxThreads, MaxThreads);
        Console.WriteLine("max threads: {0}", MaxThreads);

        for (int i = 1; i <= MaxThreads; i++)
        {
            ThreadPool.QueueUserWorkItem(PrintSomething, obj);
        }
        Thread.Sleep(5000);
        Console.WriteLine("all threads finished");
    }    
    public void RunAllThreads(object obj, int corenum)
    {
        ThreadPool.SetMaxThreads(corenum, corenum);
        Console.WriteLine("max threads: {0}", corenum);
        for (int i = 1; i <= corenum; i++)
        {
            ThreadPool.QueueUserWorkItem(PrintSomething, obj);
        }
        Thread.Sleep(5000);
        Console.WriteLine("all threads finished");
    }
}