// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");
Solution.TaskScheduler<int, int> taskScheduler = new Solution.TaskScheduler<int, int>();

int doubleNumber(int number)
{
    return number*2;
}
int squareNumber(int number)
{
    return number*number;
}

Solution.Mission<int,int> mission1 = squareNumber;
Solution.Mission<int,int> mission2 = doubleNumber;
Solution.Mission<int,int> mission3 = squareNumber;

taskScheduler.AddMission(mission1, 2000, 10);
taskScheduler.AddMission(mission2, 5000, 20);
taskScheduler.AddMission(mission3, 15000, 30);
bool finish = false;
while(!finish)
{
    Thread.Sleep(1000);
    taskScheduler.AddTime();
    taskScheduler.PrintTime();
    switch (taskScheduler.time)
    {
        case 7:
        {
            taskScheduler.RemoveMission(mission3);
            break;
        }
        case 10:
        {
            taskScheduler.RemoveMission(mission1);
            break;
        }
        case 20:
        {
            finish = true;
            break;
        }
            
    }
}