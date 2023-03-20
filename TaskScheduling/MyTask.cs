using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyTask //named mytask to not confuse self with the real task builtin class
{
    public string TaskName { get; set; }
    public int TaskTime { get; set; }
    public bool IsCompleted { get; set; }
    public MyTask(string taskName, int taskTime, bool isCompleted)
    {
        TaskName = taskName;
        TaskTime = taskTime;
        IsCompleted = isCompleted;
    }
}

