using ThreadingPanda;

PrinterAChar printerAChar = new();

Thread xThread = new Thread(() => printerAChar.Print100Chars('X'));
Thread yThread = new Thread(() => printerAChar.Print100Chars('Y'));
xThread.IsBackground = true;
yThread.IsBackground = true;

yThread.Start();

yThread.Join();
xThread.Start();

xThread.Join();

Console.WriteLine();


void PrintString(object? messageObj)
{
    string message = (string)messageObj;

    Console.WriteLine(message);
}

string helloPanda = "Hello Panda";

Thread parameterizedThread = new Thread(PrintString);
Thread parameterizedThread2 = new Thread(PrintString);

parameterizedThread.Start(helloPanda);
parameterizedThread.Join();
parameterizedThread2.Start(helloPanda);
parameterizedThread2.Join();


