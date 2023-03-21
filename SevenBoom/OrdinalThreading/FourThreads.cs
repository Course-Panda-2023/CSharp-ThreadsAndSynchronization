namespace SevenBoom.OrdinalThreading
{
    internal class FourThreads
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

            Thread thread1 = new Thread(() => SevenBoomTill200Threading(integer, 0));
            Thread thread2 = new Thread(() => SevenBoomTill200Threading(integer, 1));
            Thread thread3 = new Thread(() => SevenBoomTill200Threading(integer, 2));
            Thread thread4 = new Thread(() => SevenBoomTill200Threading(integer, 3));

            thread1.Start();
            thread1.Join();

            thread2.Start();
            thread2.Join();


            thread3.Start();
            thread3.Join();


            thread4.Start();
            thread4.Join();
        }
    }
}
