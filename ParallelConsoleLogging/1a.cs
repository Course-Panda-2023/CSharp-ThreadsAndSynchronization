namespace ParallelConsoleLogging
{
    internal class _1a : Command
    {
        private PrinterAChar? printerAChar;

        public void SetPrinterChar(PrinterAChar printerAChar)
        {
            this.printerAChar = printerAChar;
        }


        public void Execute(PrinterAChar printerAChar)
        {
            SetPrinterChar(printerAChar);
            Thread xThread = new(() => printerAChar?.Print100Chars('X'));
            Thread yThread = new(() => printerAChar?.Print100Chars('Y'));

            yThread.Start();

            yThread.Join();
            xThread.Start();

            xThread.Join();
        }


    }
}
