
using Basic;



// SevenBoom game = new SevenBoom(maxNumber: 200);
// game.Run(4);

// SevenBoomPool game2 = new SevenBoomPool(maxNumber: 200);
// game2.Run(numThreads: 4, s =>
// {
//     Console.WriteLine(s);
// });

SevenBoomBonus game3 = new SevenBoomBonus(maxNumber: 200);
game3.Run(numThreads:4, () =>
{
    Console.WriteLine("inside the callback");
});


