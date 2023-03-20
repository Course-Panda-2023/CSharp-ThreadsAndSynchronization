// See https://aka.ms/new-console-template for more information


using TaskScheduling;

Alarm<int, string> ts = new Alarm<int, string>(8);

Thread RunAlarm1 = new Thread(() => AddRemoveTask(ts));
RunAlarm1.Start();


Console.ReadLine();

static void AddRemoveTask(Alarm<int, string> ts)
{
    ts.AddTask(Solution.Func1, 5);
    //Thread.Sleep(3000);
    ts.AddTask(Solution.Func2, 10);
    //Thread.Sleep(7000);
    ts.AddTask(Solution.Func3, 15);
    ts.AddTask(Solution.Func4, 20);
    ts.AddTask(Solution.Func5, 25);
    //ts.RemoveTask(Solution.Func4);
    //Thread.Sleep(7000);
    //ts.RemoveTask(Solution.Func5);
    //Thread.Sleep(3000);
}
