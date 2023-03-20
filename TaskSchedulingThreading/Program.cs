using TaskSchedulingThreading;

TaskSchedulerCustom<int, int> schedulerCustom = new();


LimitedConcurrencyLevelTaskScheduler limitedConcurrencyLevelTask = new(100);
TaskFactory taskFactory;
CancellationTokenSource cts = new CancellationTokenSource();
taskFactory = new TaskFactory(limitedConcurrencyLevelTask);
Object lockObj = new();
int outputItem = 0;

Task<int> task1 = (Task<int>)taskFactory.StartNew((v) =>
{
    for (int outer = 0; outer <= 10; outer++)
    {
        for (int i = 0x21; i <= 0x7E; i++)
        {
            lock (lockObj)
            {
                Console.Write("'{0}' in task t1-{1} on thread {2}   ",
                              Convert.ToChar(i), 1, Thread.CurrentThread.ManagedThreadId);
                outputItem++;
                if (outputItem % 3 == 0)
                    Console.WriteLine();
            }
        }
    }
    return 0;
}, cts.Token);


Task<int> task2 = (Task<int>)taskFactory.StartNew((v) =>
{
    for (int outer = 0; outer <= 100; outer++)
    {
        for (int i = 0x21; i <= 0x7E; i++)
        {
            lock (lockObj)
            {
                Console.Write("'{0}' in task t1-{1} on thread {2}   ",
                              Convert.ToChar(i), 1, Thread.CurrentThread.ManagedThreadId);
                outputItem++;
                if (outputItem % 3 == 0)
                    Console.WriteLine();
            }
        }
    }
    return 0;
}, cts.Token);

schedulerCustom.AddTasks(task1, task2);
schedulerCustom.Execute();
Console.ReadLine();