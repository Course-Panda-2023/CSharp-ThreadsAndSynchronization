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



static void ThreadFunction(int threadNum)
{
    Console.WriteLine($"Thread {threadNum} started.");

    // Simulate some work
    Thread.Sleep(1000);

    Console.WriteLine($"Thread {threadNum} ended.");
}


int numCores = Environment.ProcessorCount;

// Define the maximum threads based on the number of cores
int maxThreads = numCores * 25;

// Create a new thread pool with the maximum number of threads
ThreadPool.SetMaxThreads(maxThreads, maxThreads);

// Queue two new tasks to the thread pool
Task task1 = Task.Factory.StartNew(() => ThreadFunction(1));
Task task2 = Task.Factory.StartNew(() => ThreadFunction(2));

// Wait for both tasks to complete
Task.WaitAll(task1, task2);

// Print something before the program ends
Console.WriteLine("Program ended.");


