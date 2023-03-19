namespace ParallelConsoleLogging
{
    internal class _2 : Command
    {
        private void PrintString(object? messageObj)
        {
            string message = (string)messageObj;

            Console.WriteLine(message);
        }


        public void Execute(PrinterAChar printerAChar)
        {
            string helloPanda = "Hello Panda";

            Thread parameterizedThread = new Thread(PrintString);
            Thread parameterizedThread2 = new Thread(PrintString);

            parameterizedThread.Start(helloPanda);
            parameterizedThread.Join();
            parameterizedThread2.Start(helloPanda);
            parameterizedThread2.Join();
        }
    }
}
