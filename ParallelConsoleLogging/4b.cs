namespace ParallelConsoleLogging
{
    internal class _4b : Command
    {
        static object lockObj = new object();

        public void Execute(PrinterAChar printerAChar)
        {
            Thread thread1 = new Thread(new ThreadStart(PrintThread1));
            Thread thread2 = new Thread(new ThreadStart(PrintThread2));

            // Start the first thread
            thread1.Start();

            // Wait for the first thread to finish
            thread1.Join();

            Console.ReadLine();

        }

        static void PrintThread1()
        {
            // Print 10 numbers
            for (int i = 1; i <= 10; i++)
            {
                lock (lockObj)
                {
                    Console.WriteLine($"Thread 1: {i}");
                }

                // Wait for 1 second before printing the next number
                Thread.Sleep(1000);
            }
        }

        static void PrintThread2()
        {
            // Print 10 letters
            for (char c = 'A'; c <= 'J'; c++)
            {
                lock (lockObj)
                {
                    Console.WriteLine($"Thread 2: {c}");
                }

                // Wait for 1 second before printing the next letter
                Thread.Sleep(1000);
            }
        }
    }
}