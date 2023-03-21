namespace ParallelConsoleLogging
{
    internal class _2 : Command
    {
        public void PrintString(object? messge)
        {
            string messageString = (string)messge;
            Console.WriteLine(messageString + "!");
        }

        public void PrintStr(object? messge)
        {
            string messageString = (string)messge;
            Console.WriteLine(messageString);
        }
        public void Execute(PrinterAChar printerAChar)
        {
            Thread thread1 = new Thread(PrintStr);
            Thread thread2 = new Thread(PrintString);
            string helloPanda = "Hello Panda";
            thread1.Start(helloPanda);
            thread1.Join();
            thread2.Start(helloPanda);
            thread2.Join();
        }
    }
}
