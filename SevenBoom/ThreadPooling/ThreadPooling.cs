namespace SevenBoom.ThreadPooling
{
    internal class ThreadPooling
    {
        private readonly uint seven = 7;

        class ObjectThatContainsInteger
        {
            public uint Value;

            public ObjectThatContainsInteger()
            {
                Value = 0;
            }
        }

        private bool isSevenBoomNumber(uint number)
        {
            return number % seven == 0 || number % 10 == seven;
        }

        private void SevenBoomTill200Threading(ObjectThatContainsInteger integer, int threadNumber)
        {

            for (uint index = 0; index < 200; ++index)
            {
                lock (integer)
                {
                    ++integer.Value;

                    if (isSevenBoomNumber(integer.Value))
                    {
                        Console.WriteLine("Boom");
                        Thread.Sleep(500);
                        continue;
                    }
                    Thread.Sleep(500);
                    Console.WriteLine(integer.Value);
                }
            }
        }

        public void Execute()
        {
            ObjectThatContainsInteger integer = new();
            for (uint index = 0; index < 4; ++index)
            {
                ThreadPool.QueueUserWorkItem((obj) => SevenBoomTill200Threading(integer, (int)index!), (object)index);
            }
        }
    }
}
