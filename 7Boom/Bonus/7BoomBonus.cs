using System;
using System.Threading;

namespace Basic
{
    public class SevenBoomBonus
    {
        const int MaxNums = 200;
        static NumObj? obj;
        private ManualResetEvent[] _resetEvents;

        public SevenBoomBonus()
        {
            obj = new NumObj();
            obj.num = 1;
            _resetEvents = new ManualResetEvent[4];
            for (int i = 0; i < _resetEvents.Length; i++)
            {
                _resetEvents[i] = new ManualResetEvent(false);
            }
        }

        public void SimulateGameForThread(int threadnum)
        {
            while (obj.num < MaxNums)
            {
                lock (obj)
                {
                    if (obj.num > MaxNums) break;
                    if (obj.num % 4 == threadnum - 1)
                    {
                        HandleNumbers();
                        Thread.Sleep(200);
                        obj.num++;
                    }
                }
            }
            _resetEvents[threadnum - 1].Set();
        }

        private static void HandleNumbers()
        {
            if (obj.num % 7 == 0 || obj.num.ToString().Contains('7')) Console.WriteLine("boom");
            else Console.WriteLine(obj.num);
        }

        public void RunGame()
        {
            Thread t1 = new Thread(() => { SimulateGameForThread(1); });
            Thread t2 = new Thread(() => { SimulateGameForThread(2); });
            Thread t3 = new Thread(() => { SimulateGameForThread(3); });
            Thread t4 = new Thread(() => { SimulateGameForThread(4); });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
        
            WaitHandle.WaitAll(_resetEvents);

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
        }
    }
}
