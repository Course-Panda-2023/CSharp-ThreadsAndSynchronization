using System;

namespace Bonus
{
    public class SevenBoomBonus
    {
        private static int count;
        private static readonly object lockObj = new object();
        private static readonly object lockPlay = new object();
        private static SevenBoomBonus instance = null;
        private SevenBoomBonus()
        {
            count = 0;
        }

        public static SevenBoomBonus Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new SevenBoomBonus();
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
            Thread thread1 = new Thread(Play);
            Thread thread2 = new Thread(Play);
            Thread thread3 = new Thread(Play);
            Thread thread4 = new Thread(Play);
            thread1.Start(1);
            thread2.Start(2);
            thread3.Start(3);
            thread4.Start(4);
        }
    }
}
