// See https://aka.ms/new-console-template for more information
using Basic;
using Bonus;
using ThreadPoolSevenPool;

Console.WriteLine("Hello, World!");

// 1. Basic
Console.WriteLine("Seven Boom");
SevenBoom sevenBoom = SevenBoom.Instance;
sevenBoom.StartGame();

// 2. ThreadPool
Console.WriteLine("Seven Boom Pool");
SevenBoomPool sevenBoomPool = SevenBoomPool.Instance;
sevenBoomPool.StartGame();

// 3. Bonus
Console.WriteLine("Bonus");
SevenBoomBonus sevenBoomBonus = SevenBoomBonus.Instance;
sevenBoomBonus.StartGame();

Console.ReadLine();