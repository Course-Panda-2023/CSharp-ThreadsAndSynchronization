using System;

class Solution
{
    
    public delegate V Mission<V,T>(T arg);
    public class TaskScheduler<V,T>
    {
        public TaskScheduler(){}
        public int time = 0;
        List<Mission<V, T>> Missions = new List<Mission<V, T>>();
        
        public void AddTime()
        {
            this.time++;
        }
        public void PrintTime()
        {
            Console.WriteLine($"Time is {this.time}");
        }
        
        public void performMission(Mission<V,T> mission, int milliseconds, T arg)
        {
            Thread.Sleep(milliseconds);
            if (this.Missions.Contains(mission))
            {
                Console.WriteLine(mission(arg));
                this.Missions.Remove(mission);
            }
        }

        public void AddMission(Mission<V,T> mission, int milliseconds, T arg)
        {
            this.Missions.Add(mission);
            Thread t = new Thread(() => performMission(mission, milliseconds, arg));
            t.Start();
        }

        public void RemoveMission(Mission<V,T> mission)
        {
            if (this.Missions.Contains(mission))
            {
                this.Missions.Remove(mission);
                Console.WriteLine("Mission removed.");
            }
            else
            {
                Console.WriteLine("Too late!");
            }
        }


    }
    
}
