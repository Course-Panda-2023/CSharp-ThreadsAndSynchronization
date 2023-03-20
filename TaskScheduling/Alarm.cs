using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TaskScheduling
{
    internal class Alarm <T,V>
    {  
        private static System.Timers.Timer timer;
        private T input;
        private static Dictionary<Func<T, V>, int> tasks;
        private static int time;

        public Alarm(T input)
        {
            tasks = new Dictionary<Func<T, V>, int>();
            time = 0;
            this.input = input;

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(tick);
            timer.Interval = 1000;
            timer.Start();

        }
        public void AddTask(Func<T, V> task, int time)
        {
            lock (this)
            {
                tasks.Add(task, time);
                Console.WriteLine("Task added ");
            }
        }

        public void RemoveTask(Func<T, V> task)
        {
            lock (this)
            {
                if(tasks.ContainsKey(task))
                {
                    int timeOfTask = tasks[task];
                    if (timeOfTask <= time)
                    {
                        Console.WriteLine("Too late!");
                    }
                    else
                    {
                        tasks.Remove(task);
                        Console.WriteLine("Task removed");
                    }
                }
            }
        }
        public void Run()
        {
            lock(this)
            {
                if(tasks.Count == 0)
                {
                    timer.Stop();
                    Console.WriteLine("Finshed all tasks");
                }
                else foreach (var t in tasks)
                {
                    if (t.Value == time)
                    {
                        Func<T, V> task = t.Key;
                        Console.WriteLine(task(input));
                        tasks.Remove(task);
                    }
                }
            }
        }
        private void tick(object sender, ElapsedEventArgs e)
        {
            time++;
            Console.WriteLine(time);
            Run();
        }

    }
}
