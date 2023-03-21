using Basic;
using Bonus;
using ThreadPool;

//SevenBoom SevenBoomGame= new SevenBoom(200);
//SevenBoomGame.initThread();

//SevenBoomPool sevenBoomPool =  new SevenBoomPool(200,4);
//sevenBoomPool.initThread();
//Console.ReadLine(); 

SevenBoomBonus sevenBoomBonus = new SevenBoomBonus(200, 4);
sevenBoomBonus.initThread();
Console.ReadLine();