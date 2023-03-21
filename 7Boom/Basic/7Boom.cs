using System;

namespace Basic
{
    public class SevenBoom
    {
        private static int count;
        private static readonly object lockObj = new object();
        private static readonly object lockPlay = new object();
        private static SevenBoom instance = null;
        private SevenBoom() { count = 0; }

        public static SevenBoom Instance {  
            get {  
                lock(lockObj) {  
                    if (instance == null) {  
                        instance = new SevenBoom();  
                    }  
                    return instance;  
                }  
            }  
        }    
    
        private static void Play()
        {
            while (count <= 200)
            {
                lock (lockPlay)
                {   
                    count++;
                    if (count <= 200)
                    {
                        if (count % 7 == 0 || count.ToString().Contains("7"))
                            Console.WriteLine("BOOM!!");
                        else
                            Console.WriteLine(count);
                    }
                }
            }
        }

        public void StartGame()
        {
            Thread thread1 = new Thread(Play);
            Thread thread2 = new Thread(Play);
            Thread thread3 = new Thread(Play);
            Thread thread4 = new Thread(Play);
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
