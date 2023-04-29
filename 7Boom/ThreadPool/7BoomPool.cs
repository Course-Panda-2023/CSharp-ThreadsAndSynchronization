using Basic;
using System;


namespace threadPool
{
    public class SevenBoomPool
    {
        int counter = 0;
        object locker = new object();
        AutoResetEvent finished = new AutoResetEvent(false);
        
        public void RunWithThreadpool(int Threads, int maxCounter)
        {
            finished.Reset();
            for (int i = 1; i <= Threads; i++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(x => threadFunc(maxCounter)));


            finished.WaitOne();
        }
        
        void threadFunc(int maxCounter)
        {
            while (true)
            {
                lock (locker)
                {
                    if (counter >= maxCounter)
                    {
                        finished.Set();
                        return;
                    }
                    Single_step_unlocked();
                    Thread.Sleep(2);
                }
            }
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
