namespace Basic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HandleInputs();
        }

        private static void HandleInputs()
        {
            while (true)
            {
                Console.WriteLine("which game do you want to access? 1. normal 2. threadpooled 3. bonus 4. exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine($"starting normal seven boom:");
                        SevenBoom s = new SevenBoom();
                        s.RunGame();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine($"starting threadpooled seven boom:");
                        SevenBoomPool sp = new SevenBoomPool();
                        sp.RunGame();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine($"starting bonus seven boom:");
                        SevenBoomBonus sb = new SevenBoomBonus();
                        sb.RunGame();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("exit");
                        return;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }

        }
    }
}

