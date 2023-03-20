namespace ParallelConsoleLogging
{
    internal class _1a : Command
    {

        public void Execute(PrinterAChar printerAChar)
        {
            Thread xThread = new(() => printerAChar?.Print100Chars('X'));
            Thread yThread = new(() => printerAChar?.Print100Chars('Y'));

            yThread.Start();

            yThread.Join();
            xThread.Start();

            xThread.Join();
        }
    }
}
