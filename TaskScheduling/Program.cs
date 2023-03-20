internal class Program
{
    private static void Main(string[] args)
    {
        Task_Scheduler t = new Task_Scheduler();
        while (true)
        {
            t.MenuPrompt();
        }
    }
}