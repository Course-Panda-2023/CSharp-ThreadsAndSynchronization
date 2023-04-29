// See https://aka.ms/new-console-template for more information
using TaskScheduling;

//Console.WriteLine("Hello, World!");

class MainClass
{
    static void foo(object state)
    {
        Console.WriteLine($"{Environment.TickCount}     {Thread.CurrentThread.ManagedThreadId} : running foo {state}");
     //   Thread.Sleep(1000);
     //   Console.WriteLine($"{Environment.TickCount}     {Thread.CurrentThread.ManagedThreadId} : running foo ");

    }


    static void Main(string[] args)
    {
        Console.WriteLine($"{Environment.TickCount}   {Thread.CurrentThread.ManagedThreadId}: Main");

        MyTaskScheduler my = new MyTaskScheduler();


        int id1 = my.Add(foo, 2000, 111);
        int id2 = my.Add(foo, 2000, 222);
        int id3 = my.Add(foo, 100, 333);
        Thread.Sleep(110);

        Console.WriteLine($"{Environment.TickCount}   {Thread.CurrentThread.ManagedThreadId}: Removing");
        my.Remove(id3);
        Thread.Sleep(10000);
    }
}