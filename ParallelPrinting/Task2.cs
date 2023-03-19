public class Task2
{
    public Task2()
    {
    }
    public void PrintSomething5Times(object obj)
    {
        string str = (string)obj;
        Console.WriteLine($"{Thread.CurrentThread.Name} started");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} says {str}");
            Thread.Sleep(100);
        }
        Console.WriteLine($"{Thread.CurrentThread.Name} ended");

    }

    public void RunAllThreads(string str)
    {
        Thread t1 = new Thread(new ParameterizedThreadStart(PrintSomething5Times));
        Thread t2 = new Thread(new ParameterizedThreadStart(PrintSomething5Times));

        t1.Name = "thread 1";
        t2.Name = "thread 2";

        t1.Start(str);
        t2.Start(str);
        t1.Join();
        t2.Join();
        Console.WriteLine("all threads ended");
    }
}