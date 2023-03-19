using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TaskScheduling
{
    public class TaskScheduling <T, V>
    {
        private static Dictionary<Func<T, V>, int> taskQueue;
        private static int count;
        private static System.Timers.Timer timer;
        private T input;

        public TaskScheduling(T input)
        {
            taskQueue = new Dictionary<Func<T, V>, int>();
            count = 0;
            this.input = input;
            InitTimer();
        }
        public void InitTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();
        }
        public void AddTask(Func<T, V> task, int time)
        {
            lock (this)
            {
                taskQueue.Add(task, time);
                Console.WriteLine($"Task added successfully");
            }
        }

        public void RemoveTask(Func<T, V> task)
        {
            lock (this)
            {
                if(taskQueue.ContainsKey(task))
                {
                    var t = taskQueue[task];
                    if (t <= count)
                    {
                        Console.WriteLine("Too late!");
                    }
                    else
                    {
                        taskQueue.Remove(task);
                        Console.WriteLine($"Task removed successfully");
                    }
                }
            }
        }
        public void RunProgram()
        {
            lock(this)
            {
                foreach (var t in taskQueue)
                {
                    if (t.Value == count)
                    {
                        Func<T, V> task = t.Key;
                        Console.WriteLine(task(input));
                    }
                }
            }
        }
        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            count++;
            Console.WriteLine(count);
            RunProgram();
        }
    }
}
