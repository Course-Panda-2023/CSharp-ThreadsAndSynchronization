using _7Boom.Basic;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;

namespace Basic
{
    public class SevenBoom
    {
        const int numberLimit = 200;
        static NumObj obj;

        public SevenBoom()
        {
            obj = new NumObj();
            obj.Num = 1;
        }

        static void Function1()
        {
            FunctionHelper(1);
        }
        static void Function2()
        {
            FunctionHelper(2);
        }
        static void Function3()
        {
            FunctionHelper(3);
        }
        static void Function4()
        {
            FunctionHelper(4);
        }

        static void FunctionHelper(int threadNum)
        {
            const int numOfThreads = 4;
            const int seven = 7;
            while (obj.Num <= numberLimit)
            {
                lock (obj)
                {
                    if (obj.Num % numOfThreads == (threadNum - 1) && obj.Num <= numberLimit)
                    {
                        string currentNum = obj.Num.ToString();
                        if (obj.Num % seven == 0 || currentNum.Contains(seven.ToString()))
                        {
                            Console.WriteLine("Boom");
                        }
                        else
                        {
                            Console.WriteLine(obj.Num);
                        }
                        obj.Num++;
                    }
                }
            }
        }

        public void run()
        {
            Thread thread1 = new Thread(Function1);
            Thread thread2 = new Thread(Function2);
            Thread thread3 = new Thread(Function3);
            Thread thread4 = new Thread(Function4);

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

        }
    }
}
