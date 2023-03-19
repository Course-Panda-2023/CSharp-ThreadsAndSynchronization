using System;
using System.Threading;


public class TaskSchedule <T, V>
{
    public delegate T ToDo(V v);
    private V argument;
    private Dictionary<ToDo, int> taskTimes;
    private int startTime;
    public TaskSchedule(V argument)
    {
        this.startTime = (int) (DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        this.taskTimes = new Dictionary<ToDo, int>();
        this.argument = argument;
    }
    public void AddTask(ToDo todo, int time)
    {
        lock (taskTimes)
        {
            taskTimes[todo] = time;
        }
    }
    public void RemoveTask(ToDo todo)
    {
        lock(taskTimes)
        {
            foreach (ToDo other_todo in taskTimes.Keys)
            {
                if (other_todo == todo)
                {
                    int now = (int)(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    if (now < this.startTime + taskTimes[todo])
                    {
                        taskTimes.Remove(todo);
                    }
                    else
                    {
                        Console.WriteLine("Too Late!");
                    }
                }
            }
        }
        
    }
    public void CheckTask()
    {
        lock (taskTimes)
        {
            foreach (ToDo todo in taskTimes.Keys)
            {
                int now = (int)(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                if (now == this.startTime + taskTimes[todo])
                {
                    Console.WriteLine(todo(this.argument)); 
                }
            }
        }
        
    }
}




























public class Solution
{

    public static void Assignment1()
    {
        /*
        * Write code here
        */
    }

    public static void Assignment2()
    {
        /*
        * Write code here
        */
    }

    public static void Assignment3()
    {
        /*
        * Write code here
        */
    }

    public static void Assignment4()
    {
        /*
        * Write code here
        */
    }

    public static void Assignment5()
    {
        /*
        * Write code here
        */
    }
}
