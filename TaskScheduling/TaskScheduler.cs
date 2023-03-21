public class Task_Scheduler<T, V> where T : Delegate
{
    private DateTime startTime;
    private int elapsedSeconds;
    private List<MyTask<T, V>> taskList;

    public Task_Scheduler()
    {
        startTime = DateTime.Now;
        elapsedSeconds = 0;

        Thread t = new Thread(new ThreadStart(UpdateElapsedSeconds));
        t.Start();

        taskList = new List<MyTask<T, V>>();
    }

    public int ElapsedSeconds
    {
        get { return elapsedSeconds; }
    }

    public event EventHandler ElapsedSecondsChanged;

    private void UpdateElapsedSeconds()
    {
        while (true)
        {
            int oldElapsedSeconds = elapsedSeconds;
            elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;

            if (elapsedSeconds != oldElapsedSeconds)
            {
                ElapsedSecondsChanged?.Invoke(this, EventArgs.Empty);
                OnElapsedSecondsChanged();
            }

            Thread.Sleep(1000);
        }
    }

    public void AddTask(MyTask<T, V> task, int taskTime)
    {
        if (taskTime <= elapsedSeconds)
        {
            throw new Exception("task time must be at future");
        }

        task.TaskTime = taskTime;
        taskList.Add(task);
    }

    private void OnElapsedSecondsChanged()
    {
        foreach (var task in taskList.ToArray())
        {
            if (task.TaskTime == elapsedSeconds)
            {
                PerformTask(task);
            }
        }
    }


    private void PerformTask(MyTask<T, V> task)
    {
        if (!task.IsCompleted)
        {
            task.IsCompleted = true;
            task.Result = (V?)task.TaskFunction.DynamicInvoke(task.Parameters);
        }
    }


    public void RemoveTask(MyTask<T, V> task)
    {
        if (taskList.Contains(task))
        {
            if (task.IsCompleted)
            {
                Console.WriteLine("too late ):");
                return;
            }
            else
            {
                taskList.Remove(task);
                Console.WriteLine("removed successfully!.");
            }
        }
    }

}
