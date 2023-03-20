using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyTask<T, U> //named mytask to not confuse self with the real task builtin class
{
    public T TaskName { get; set; }
    public int TaskTime { get; set; }
    public bool IsCompleted { get; set; }
    public MyTask(T taskName, int taskTime, bool isCompleted)
    {
        TaskName = taskName;
        TaskTime = taskTime;
        IsCompleted = isCompleted;
    }
}

