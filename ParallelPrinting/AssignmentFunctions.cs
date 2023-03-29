
abstract class AssignmentFunctions
{
    public static void PrintChar(char c, int numOfTimes)
    {
        for (int i=0; i<numOfTimes; i++)
        {
            Console.WriteLine(c);
        }
    }

    
    public static void PrintStr(Object obj)
    {
        object[] array = obj as object[];
        string str = Convert.ToString(array[0]);
        Thread thread = Thread.CurrentThread;
        string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}, prints: {str}";
        Console.WriteLine(message);
    }

    public static void PrintNumbers()
    {
        for (int i=1; i<=100; i++)
        {
            Console.WriteLine(i);
        }
    }


    public static object locks = new object();

    public static void Values()
    {
        Monitor.Enter(locks);
        try
        {
            for (int z = 1; z <= 4; z++)
            {
                Thread.Sleep(750);
                Console.WriteLine(z + "");
            }

        }
        finally
        {
            Monitor.Exit(locks);
        }
    }

}