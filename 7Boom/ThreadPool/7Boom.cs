using System;

using System.Threading;

namespace ThreadPool
{
    public class SevenBoomPool
    {

        private int _limit;
        private object _CounterObject;
        private int _numOfPlayers;
        private const int _seven = 7;

        public SevenBoomPool(int limit, int numOfPlayers)
        {
            _limit = limit;
            _numOfPlayers = numOfPlayers;
            _CounterObject = 0;
        }

        public void initThread()
        {
            for (int i = 1; i <= _numOfPlayers; i++)
                System.Threading.ThreadPool.QueueUserWorkItem(play, i);

        }

        public void play(object thredNumber)
        {
            int currNum;
            while (true)
            {
                Thread.Sleep(2);
                lock (_CounterObject)
                {
                    currNum = (int)_CounterObject;
                    if (currNum < _limit)
                    {
                        if (myTurn((int)thredNumber, currNum))
                        {
                            currNum++;
                            _CounterObject = currNum;
                            mCallBack(currNum, (int)thredNumber);
                        }
                    }
                    else
                        break;
                }
            }
            if ((int)thredNumber == _numOfPlayers)
                Console.WriteLine("GAME OVER!!!!!");
            //Console.WriteLine((int)thredNumber);
        }

        public bool boom(int num)
        {
            return num % _seven == 0 || num % 10 == _seven || (num / 10) % 10 == _seven;
        }
        public bool myTurn(int name, int num)
        {
            return name - 1 == num % _numOfPlayers;
        }
        public void mCallBack(int num,int name)
        {
            string currentNum = num.ToString();
            if (boom(num))
                Console.WriteLine($"Thread {name} : {num} BOOOOOOOMMMM!!!!!");
            else
                Console.WriteLine($"Thread {name} : {num}");
        }

    }




}
