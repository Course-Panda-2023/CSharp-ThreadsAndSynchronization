using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelConsoleLogging
{
    interface Command
    {
        void Execute(PrinterAChar printerAChar);
    }
}
