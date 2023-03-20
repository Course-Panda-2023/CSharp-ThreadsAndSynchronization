using System;

using System;

namespace Basic
{
    public class SevenBoomPool
    {
        const int MaxNums = 200;
        static NumObj? obj;
        public SevenBoomPool()
        {
            obj = new NumObj();
            obj.num = 1;
        }
        public void SimulateGameForThread(object threadnum)
        {
            int threadindex = Convert.ToInt32(threadnum);
            while (true)
            {
                lock (obj)
                {
                    if (obj.num > MaxNums) break;
                    if (obj.num % 4 == threadindex - 1)
                    {
                        HandleNumbers();
                        Thread.Sleep(200);
                        obj.num++;
                    }
                }
            }
        }

        private static void HandleNumbers()
        {
            if (obj.num % 7 == 0 || obj.num.ToString().Contains('7')) Console.WriteLine("boom");
            else Console.WriteLine(obj.num);
        }

        public void RunGame()
        {
            int MaxThreads = 4;
            ThreadPool.SetMaxThreads(MaxThreads, MaxThreads);
            for (int i = 0; i < MaxThreads; i++)
            {
                ThreadPool.QueueUserWorkItem(SimulateGameForThread, i + 1);
            }
        }
    }
}
