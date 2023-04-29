using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace TaskScheduling
{
    public class MyTaskScheduler
    {
        DateTime start = DateTime.Now;

        public delegate void TaskDelegate(object state);
        Dictionary<int, TaskDelegate?> delegateList = new Dictionary<int, TaskDelegate?>();

        public int currentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns>ID of new tast</returns>
        public int Add(TaskDelegate d, int ms_from_start, object T)
        {
            lock (this)
            {
                currentID++;
                int id = currentID;
                delegateList.Add(id, d);
                Task.Run(() => Execute(id, ms_from_start, T));
                return id;
            }
        }

        public void Remove(int id)
        {
            try
            {
                TaskDelegate? del = delegateList[id];
                delegateList[id] = null;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Too late");
            }
        }

        private void Execute(int id, int time_ms, object T)
        {
            
            Console.WriteLine($"{Environment.TickCount}   {Thread.CurrentThread.ManagedThreadId}: starting timer");
            Thread.Sleep(Math.Max((int)start.AddMilliseconds(time_ms).Subtract(DateTime.Now).TotalMilliseconds,0));
            bool exists = delegateList.TryGetValue(id, out TaskDelegate? d);
            if (exists)
            {
                delegateList.Remove(id);

                if (d != null)
                {
                    d(T);
                    Console.WriteLine($"{Environment.TickCount}   {Thread.CurrentThread.ManagedThreadId}: finished action on {T}");
                }
            }


            //TODO:
            //if (id in delegateList)
            //{
            //  call func_d(T)
            //}


        }
    }
}
