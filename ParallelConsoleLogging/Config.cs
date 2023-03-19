using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Utils.CustomExceptions;

namespace ParallelConsoleLogging
{
    internal class Config
    {
        NameValueCollection keywordsThatReferToTheSameThing = new()
        {
            { "Exercise 1", "Ex1.a" },
            { "Exercise 1 Part a", "Ex1.b" },
            { "Exercise 1 Part b", "Ex1.b" },
            { "Exercise 2", "Ex2" },
            { "Exercise 3" , "Ex3" },
            { "Exercise 4.a" , "Ex4.a" },
            { "Exercise 4.b" , "Ex4.b" }
        };

        /*
         * { "Ex1.a", "Exercise 1" },
            { "Ex1.b", "Exercise 1 Part a" },
            { "Ex1.b", "Exercise 1 Part b" },
            { "Ex2", "Exercise 2" },
            { "Ex3", "Exercise 3" },
            { "Ex4.a", "Exercise 4.a" },
            { "Ex4.b", "Exercise 4.b" }
         * */

        public Dictionary<string, Command> Commands = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Ex1.a", new _1a() },
            { "Ex1.b", new _1b() },
            { "Ex2", new _2() },
            { "Ex3", new _3() },
            { "Ex4.a", new _4a() },
            { "Ex4.b", new _4b() }

        };

        private PrinterAChar? printerAChar;

        public void SetPrinterChar(PrinterAChar printerAChar)
        {
            this.printerAChar = printerAChar;
        }

        public Command GetCommand(string command)
        {
            ref var valOrNull = ref CollectionsMarshal.GetValueRefOrNullRef(Commands, command);

            if (!Unsafe.IsNullRef(ref valOrNull))
            {
                return valOrNull;
            }

            string? keyword = keywordsThatReferToTheSameThing.Get(command);
            if (keyword == null) throw new CommandNotFoundException("Command Not Found");

            // if there is exception here thus keywordsThatReferToTheSameThing not binds to Commands
            return Commands[keyword];

        }
    }
}
