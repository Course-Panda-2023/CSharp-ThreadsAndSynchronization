namespace ThreadingPanda
{
    internal class PrinterAChar
    {
        public void Print100Chars(char character)
        {
            for (uint i = 0; i < 100; ++i)
            {
                Console.Write($"{character} ");
            }
        }
    }
}
