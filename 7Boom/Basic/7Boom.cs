using System;

namespace Basic
{
    public class SevenBoom
    {
        int counter = 0;
        object locker = new object();

        public void Run(int Threads, int maxCounter)
        {
            List<Thread> Threadlist = new List<Thread>();
            for (int i = 1; i <= Threads; i++)
            {
                Threadlist.Add(new Thread(() => ThreadFunc(maxCounter)) { Name = i.ToString() });
            }
            foreach (Thread t in Threadlist)
                t.Start();
            foreach (Thread t in Threadlist)
                t.Join();
        }


        void ThreadFunc(int maxCounter)
        {
            while (true)
            {
                lock (locker)
                {
                    if (counter >= maxCounter)
                    {
                        return;
                    }
                    Single_step_unlocked();
                    Thread.Sleep(2);
                }

                void Single_step_unlocked()
                {
                    counter++;
                    if ((counter % 7 == 0) || (counter.ToString().Contains('7')))
                        Console.WriteLine("Boom");
                    else
                        Console.WriteLine(counter);
                }
            }

        }
    }
}