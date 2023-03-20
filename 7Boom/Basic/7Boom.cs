﻿using System;

namespace Basic
{
    public class SevenBoom
    {
        const int MaxNums = 200;
        static NumObj? obj;
        public SevenBoom()
        {
            obj = new NumObj();
            obj.num = 1;
        }
        public void SimulateGameForThread(int threadnum)
        {
            while (obj.num < MaxNums)
            {
                lock(obj)
                {
                    if (obj.num <= 200)
                    {
                        if (obj.num % 4 == threadnum - 1)
                        {
                            HandleNumbers();
                            Thread.Sleep(200);
                            obj.num++;
                        }
                    } else
                    {
                        break;
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
            Thread t1 = new Thread(() => { SimulateGameForThread(1); });
            Thread t2 = new Thread(() => { SimulateGameForThread(2); });
            Thread t3 = new Thread(() => { SimulateGameForThread(3); });
            Thread t4 = new Thread(() => { SimulateGameForThread(4); });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
        }
    }
}
