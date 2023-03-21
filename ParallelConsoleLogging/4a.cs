namespace ParallelConsoleLogging
{
    internal class _4a : Command
    {
        static void PrintNumbers()
        {
            // Print numbers from 1 to 100 with a 2 second delay after each number is printed
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);

                // Wait for 2 seconds before printing the next number
                Thread.Sleep(2000);
            }
        }

        public void Execute(PrinterAChar printerAChar)
        {
            Thread newThread = new Thread(new ThreadStart(PrintNumbers));

            // Start the new thread
            newThread.Start();

            // Wait for the new thread to finish
            newThread.Join();

            // Print a message to the console indicating that the thread has ended
            Console.WriteLine("Thread ended printing");

            Console.ReadLine();
        }
    }
}
