using System;
using System.Threading;

namespace ThreadPoolSevenPool
{
    public class SevenBoomPool
    {
        private static int count;
        private static readonly object lockObj = new object();
        private static readonly object lockPlay = new object();
        private static SevenBoomPool instance = null;
        private SevenBoomPool() 
        { 
            count = 0; 
        }

        public static SevenBoomPool Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new SevenBoomPool();
                    }
                    return instance;
                }
            }
        }

        private void Play(Object obj)
        {
            while (count <= 200)
            {
                lock (lockPlay)
                {
                    int number = (int)obj;
                    count++;
                    if (count <= 200)
                    {
                        if (count % 7 == 0 || count.ToString().Contains("7"))
                            Console.WriteLine($"{number}. BOOM!!");
                        else
                            Console.WriteLine($"{number}. {count}");
                    }
                    Thread.Sleep(500);
                }
            }
        }

        public void StartGame()
        {
            ThreadPool.SetMaxThreads(4, 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Play), 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Play), 2);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Play), 3);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Play), 4);
        }

    }
}
