using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
