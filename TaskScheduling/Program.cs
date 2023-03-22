using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        TaskSchedule<string, string> schedule = new TaskSchedule<string, string>("amir ");
        var t = new Thread(() => AddRemoveTasks(schedule));
        t.Start();
        while (true)
        {
            Thread.Sleep(1000);
            schedule.CheckTask();
        }
    }
    public static void AddRemoveTasks(TaskSchedule<string, string> schedule)
    {
        Thread.Sleep(1000);
        schedule.AddTask(StringFunc1, 3);
        Thread.Sleep(1000);
        schedule.AddTask(StringFunc2, 4);
        Thread.Sleep(2000);
        schedule.AddTask(StringFunc3, 6);
        Thread.Sleep(1000);
        schedule.RemoveTask(StringFunc3);
        Thread.Sleep(1000);
        schedule.RemoveTask(StringFunc1);

    }
    public static string StringFunc1(string str) {return str + " hii"; }
    public static string StringFunc2(string str) {return str + " yo-yo"; }
    public static string StringFunc3(string str) { return str + " da best";  }
    public static string StringFunc4(string str) { return str + " ya boi"; }
}
