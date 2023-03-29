using System;
using System.Threading;

public class SevenBoomPool
{
    private int _maxNumber;
    private int _counter = 1;
    private object _lock = new object();

    public SevenBoomPool(int maxNumber)
    {
        _maxNumber = maxNumber;
    }

    public void Run(int numThreads, Action<string> mCallBack)
    {
        CountdownEvent countdown = new CountdownEvent(numThreads);
        
        for (int i = 1; i <= numThreads; i++)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object state) =>
            {
                string message;
                
                while (true)
                {
                    Thread.Sleep(100);
                    lock (_lock)
                    {
                        if (_counter == _maxNumber + 1)
                        {
                            break;
                        }
                        message = (_counter % 7 == 0) || _counter.ToString().Contains("7") ? "Boom" : _counter.ToString();
                        mCallBack(message);
                        
                        _counter++;
                    }
                }
                
                countdown.Signal();
            }));
        }

        countdown.Wait();
    }
}