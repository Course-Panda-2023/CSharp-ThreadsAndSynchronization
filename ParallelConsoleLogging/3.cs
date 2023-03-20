namespace ParallelConsoleLogging
{
    internal class _3 : Command
    {
        static void Thread1(object state)
        {
            Console.WriteLine("Thread 1 is running");
        }

        static void Thread2(object state)
        {
            Console.WriteLine("Thread 2 is running");
        }

        public void Execute(PrinterAChar printerAChar)
        {
            // Get the number of cores in the machine
            int numCores = Environment.ProcessorCount;

            // Allocate 25 threads per core
            int maxThreads = 25 * numCores;

            // Create a thread pool with the maximum number of threads
            ThreadPool.SetMaxThreads(maxThreads, maxThreads);

            // Queue up two new threads
            ThreadPool.QueueUserWorkItem(new WaitCallback(Thread1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Thread2));

            // Wait for the threads to complete before ending the program
            Console.ReadLine();
        }
    }
}
