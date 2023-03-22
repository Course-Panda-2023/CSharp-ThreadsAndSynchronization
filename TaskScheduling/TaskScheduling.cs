using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Threads
{
    public class TaskScheduling <T, V>
    {
        private static System.Timers.Timer timer;
        private static Dictionary<Func<T, V>, int> tasks;
        private static int currentTime;
        private T taskInput;
        public TaskScheduling(T taskInput)
        {
            this.taskInput = taskInput;
            tasks = new Dictionary<Func<T, V>, int>();
            currentTime = 0;
            StartTimer();
        }
        public void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(TimeListener);
            timer.Interval = 1000;
            timer.Start();
        }
        public void TimeListener(object sender, ElapsedEventArgs e)
        {
            currentTime++;
            Console.WriteLine($"Current Time Is: {currentTime}");
            CheckForTask();
        }
        public void AddTask(Func<T, V> task, int time)
        {
            tasks.Add(task, time);
            Console.WriteLine($"Task Added To Time: {time}");
        }
        public void RemoveTask(Func<T, V> task)
        {
            if (tasks.ContainsKey(task))
            {
                int taskTime = tasks[task];
                if (taskTime <= currentTime)
                    Console.WriteLine("Too Late, Task Already Done !");
                else
                {
                    tasks.Remove(task);
                    Console.WriteLine("Task Removed !");
                }
            }
        }
        public void CheckForTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("All Tasks Done !");
                timer.Stop();
            }
            else
                foreach (var task in tasks)
                {
                    if (task.Value == currentTime)
                    {
                        Func<T, V> taskFunc = task.Key;
                        Console.WriteLine(taskFunc(taskInput));
                        tasks.Remove(taskFunc);
                    }
                }
        }
    }
}
