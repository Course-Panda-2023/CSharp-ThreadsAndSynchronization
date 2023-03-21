using System;
using _7Boom.Bonus;

namespace Bonus
{
    public class SevenBoomBonus
    {
        const int numOfThreads = 4;
        const int numberLimit = 200;
        const int pauseTime = 100;
        static NumObj obj;

        public SevenBoomBonus()
        {
            obj = new NumObj();
            obj.Num = 1;
        }
        static void Function(object o)
        {
            while (obj.Num <= numberLimit)
            {
                Thread.Sleep(pauseTime * numOfThreads);
                mCallBack(obj.Num);
                obj.Num++;
            }
        }

        static void mCallBack(int num)
        {
            const int seven = 7;
            string currentNum = num.ToString();
            if(num <= numberLimit)
            {
                if (num % seven == 0 || currentNum.Contains(seven.ToString()))
                {
                    Console.WriteLine("Boom");
                }
                else
                {
                    Console.WriteLine(num);
                }
            }
        }

        public void Run()
        {
            for (int i = 1; i <= numOfThreads; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(Function);
                Thread.Sleep(100);
            }
        }
    }
}
