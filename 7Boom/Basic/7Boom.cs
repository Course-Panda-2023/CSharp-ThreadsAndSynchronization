using System;

namespace Basic
{
    public class SevenBoom
    {
        private int _limit;
        private object _CounterObject;
        private const int _numOfPlayers=4;
        private const int _seven = 7;

        public SevenBoom(int limit) 
        {
            _limit = limit;
            _CounterObject = 0;
        }

        public void initThread()
        {
            Thread thread1 = new Thread(() => play());
            Thread thread2 = new Thread(() => play());
            Thread thread3 = new Thread(() => play());
            Thread thread4 = new Thread(() => play());
            thread1.Name = "1";
            thread2.Name = "2";
            thread3.Name = "3";
            thread4.Name = "4";
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }

        public void play()
        {
            int currNum;
            while (true) 
            {
                Thread.Sleep(1);
                lock (_CounterObject) 
                {
                    currNum = (int)_CounterObject;
                    if (currNum < _limit )
                    {
                        if(myTurn(Thread.CurrentThread.Name,currNum))
                        {
                            currNum++;
                            _CounterObject = currNum;
                            if(boom(currNum))
                                Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {currNum} BOOOOOOOMMMM!!!!!");
                            else
                                Console.WriteLine($"Thread {Thread.CurrentThread.Name} : {currNum} ");
                        }
                    }
                    else
                        break;
                }
            }
            if(int.Parse(Thread.CurrentThread.Name) == _numOfPlayers)
                Console.WriteLine("GAME OVER!!!!!");
        }

        public bool boom (int num) 
        {
            return num % _seven == 0 || num % 10 == _seven || (num / 10) % 10 == _seven;
        }
        public bool myTurn(string name , int num)
        {
            return int.Parse(name) - 1 == num % _numOfPlayers;
        }

    }
}
