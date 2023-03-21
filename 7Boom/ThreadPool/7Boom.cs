using _7Boom.Basic;
using System.Threading;
using System;

namespace ThreadPool
{
    public class SevenBoomPool
    {
        const int numberLimit = 200;
        const int numOfThreads = 4;
        static NumObj obj;

        public SevenBoomPool()
        {
            obj = new NumObj();
            obj.Num = 1;
        }

        static void Function(object threadNum)
        {
            while (obj.Num <= numberLimit)
            {
                lock (obj)
                {
                    if (obj.Num % numOfThreads == ((int)threadNum - 1) && obj.Num <= numberLimit)
                    {
                        mCallBack(obj.Num);
                        obj.Num++;
                    }
                }
            }
        }

        static void mCallBack(int num)
        {
            const int seven = 7;
            string currentNum = num.ToString();
            if (num % seven == 0 || currentNum.Contains(seven.ToString()))
            {
                Console.WriteLine("Boom");
            }
            else
            {
                Console.WriteLine(num);
            }
        }

        public void run()
        {
            for (int i = 1; i <= numOfThreads; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(Function, i);
            }
            Thread.Sleep(1000);
        }
    }
}
