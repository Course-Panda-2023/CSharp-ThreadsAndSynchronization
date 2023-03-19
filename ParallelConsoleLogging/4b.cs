using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelConsoleLogging
{
    internal class _4b : Command
    {
        private static readonly object lockObject = new object();
        public void PrintNumbers1()
        {
            for (int i = 1; i <= 100; i++)
            {
                lock (lockObject)
                {
                    Console.WriteLine($"Thread 1: {i}");
                    Thread.Sleep(100);
                }
            }
        }

        public void PrintNumbers2()
        {
            for (int i = 1; i <= 100; i++)
            {
                lock (lockObject)
                {
                    Console.WriteLine($"Thread 2: {i}");
                    Thread.Sleep(100);
                }
            }
        }
        public void Execute(PrinterAChar printerAChar)
        {
            Thread printingThread1 = new Thread(PrintNumbers1);
            Thread printingThread2 = new Thread(PrintNumbers2);
            printingThread1.Start();
            printingThread2.Start();

            // Wait for both printing threads to finish before exiting the program
            printingThread1.Join();
            printingThread2.Join();

            Console.WriteLine("Main thread ended");

        }
    }
}