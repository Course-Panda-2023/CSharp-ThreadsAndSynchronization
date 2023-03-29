using System;

namespace Basic
{
    public class SevenBoom
    {
        static object lock_object = new object();
        static int sharedInt = 0;

        public static void IncrementAndCheckBoom(int threadNumber)
        {
            while (true)
            {
                lock (lock_object)
                {
                    if (sharedInt >= 200)
                    {
                        break;
                    }

                    sharedInt++;

                    if (IsBoom(sharedInt))
                    {
                        Console.WriteLine($"Thread {threadNumber}: Boom");
                    }
                    else
                    {
                        Console.WriteLine($"Thread {threadNumber}: {sharedInt}");
                    }
                }
            }
        }

        static bool IsBoom(int number)
        {
            if (number % 7 == 0 || number.ToString().Contains("7"))
                return true;
            else
                return false;
        }
    

        public static void Run()
        {
            Thread[] threads = new Thread[4];

            for (int i = 0; i < 4; i++)
            {
                int threadNumber = i + 1;
                threads[i] = new Thread(() => IncrementAndCheckBoom(threadNumber));
                threads[i].Start();
            }

            for (int i = 0; i < 4; i++)
            {
                threads[i].Join();
            }
        }
    }
}
