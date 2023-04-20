using System;
using System.Threading;

public class Program
{
    public delegate int AddDelegate(int a, int b);

    public static int AddNumbers(int a, int b)
    {
        Console.WriteLine($"{a} + {b} = {a+b}");
        return a + b;
    }

    public static void Main(string[] args)
    {
        Task_Scheduler<AddDelegate, int> taskScheduler = new Task_Scheduler<AddDelegate, int>();

        AddDelegate addFunction = new AddDelegate(AddNumbers);
        MyTask<AddDelegate, int> myTask = new MyTask<AddDelegate, int>(addFunction, 5, 3, 4);

        taskScheduler.ElapsedSecondsChanged += (sender, e) =>
        {
            Console.WriteLine($"seconds: {taskScheduler.ElapsedSeconds}");
        };

        taskScheduler.AddTask(myTask, 5);

        Console.WriteLine("Press any key to remove the task.");
        Console.ReadKey();

        taskScheduler.RemoveTask(myTask);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

}
