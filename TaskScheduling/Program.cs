using static Solution;
using TaskScheduling;


TaskScheduling<int, string> ts = new TaskScheduling<int, string>(8);

Thread TaskAdderAndRemover = new Thread(() => AddRemoveTask(ts));
TaskAdderAndRemover.Start();

Console.ReadLine();

static void AddRemoveTask(TaskScheduling<int, string> ts)
{
    ts.AddTask(Function1, 5);
    Thread.Sleep(3000);
    ts.AddTask(Function5, 30);
    Thread.Sleep(7000);
    ts.AddTask(Function3, 13);
    ts.RemoveTask(Function1);
    Thread.Sleep(7000);
    ts.RemoveTask(Function5);
    Thread.Sleep(3000);
}