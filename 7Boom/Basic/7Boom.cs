namespace Basic
{
    class SevenBoom
    {
        private int _maxNumber;
        private int _counter = 1;
        private object _counterLock = new object();

        public SevenBoom(int maxNumber)
        {
            _maxNumber = maxNumber;
        }

        public void Run(int numThreads)
        {
            Parallel.ForEach(Enumerable.Range(1, numThreads).ToList(), threadNumber =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    lock (_counterLock)
                    {
                        if (_counter == _maxNumber + 1)
                        {
                            break;
                        }
                        
                        if ((_counter % 7 == 0) || _counter.ToString().Contains("7"))
                        {
                            Console.WriteLine($"Thread #{threadNumber}: Boom");
                        }
                        else
                        {
                            Console.WriteLine($"Thread #{threadNumber}: {_counter}");
                        }

                        _counter++;
                    }
                }
            });
        }
    }
}
