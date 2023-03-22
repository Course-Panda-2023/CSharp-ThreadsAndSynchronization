using static Solution;
using TaskScheduling;


TaskScheduling<int, string> ts = new TaskScheduling<int, string>();

//Thread TaskAdderAndRemover = new Thread(() => AddRemoveTask(ts));
//TaskAdderAndRemover.Start();
Tasks<int, string> t1 = new Tasks<int, string>(Function1, 8);
Tasks<int, string> t2 = new Tasks<int, string>(Function3, 20);
Tasks<int, string> t3 = new Tasks<int, string>(Function5, 78);


ts.AddTask(t1, 5);
Thread.Sleep(3000);
ts.AddTask(t3, 30);
Thread.Sleep(7000);
ts.AddTask(t2, 13);
ts.RemoveTask(t1);
Thread.Sleep(7000);
ts.RemoveTask(t3);
Thread.Sleep(3000);

Console.ReadLine();

//static void AddRemoveTask(TaskScheduling<int, string> ts)
//{
//    ts.AddTask(Function1, 5);
//    Thread.Sleep(3000);
//    ts.AddTask(Function5, 30);
//    Thread.Sleep(7000);
//    ts.AddTask(Function3, 13);
//    ts.RemoveTask(Function1);
//    Thread.Sleep(7000);
//    ts.RemoveTask(Function5);
//    Thread.Sleep(3000);
//}