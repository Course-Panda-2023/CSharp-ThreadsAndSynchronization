namespace ParallelConsoleLogging
{
    internal class _1b : Command
    {
        public void Execute(PrinterAChar printerAChar)
        {
            Thread xThread = new(() => printerAChar.Print100Chars('X'));
            Thread yThread = new(() => printerAChar.Print100Chars('Y'));
            xThread.IsBackground = true;
            yThread.IsBackground = true;

            yThread.Start();

            yThread.Join();
            xThread.Start();

            xThread.Join();

        }
    }
}
