
using ParallelConsoleLogging;
using System.Collections.Specialized;

PrinterAChar printerAChar = new();

unsafe
{ 
    int* p = stackalloc int[1];
    *p = (int)'A';
    Console.WriteLine(*p);
}

Config Config = new();

foreach (var key in Config.Commands.Keys)
{
    Console.WriteLine(key);
}

string? userInput = Console.ReadLine();

if (userInput == null) return;
Command command = Config.GetCommand(userInput);

command.Execute(printerAChar);

Console.ReadLine();