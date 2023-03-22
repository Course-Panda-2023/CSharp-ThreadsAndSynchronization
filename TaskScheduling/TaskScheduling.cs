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
        private static Dictionary<Tasks<T, V>, int> taskQueue;
        private static int count;
        private static System.Timers.Timer timer;

        public TaskScheduling()
        {
            taskQueue = new Dictionary<Tasks<T, V>, int>();
            count = 0;
            InitTimer();
        }
        public void InitTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Interval = 1000;
            timer.Start();
        }
        public void AddTask(Tasks<T, V> task, int time)
        {
            taskQueue.Add(task, time);
            Console.WriteLine($"Task added successfully");
        }

        public void RemoveTask(Tasks<T, V> task)
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
        public void RunProgram()
        {
            if(taskQueue.Count == 0)
            {
                timer.Stop();
                Console.WriteLine("No more tasks to run. Enter any key to end the program.");
            }
            else foreach (var t in taskQueue)
            {
                if (t.Value == count)
                {
                    Tasks<T, V> task = t.Key;
                    ThreadPool.QueueUserWorkItem(PrintFuncOutput, task);
                    taskQueue.Remove(task);
                }
            }
        }
        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            count++;
            Console.WriteLine(count);
            RunProgram();
        }

        public void PrintFuncOutput(object obj)
        {
            Tasks<T, V> task = (Tasks<T, V>)obj;
            Console.WriteLine(task.Task(task.Parameter));
        }
    }
}
