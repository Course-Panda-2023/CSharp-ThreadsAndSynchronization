using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Race
    {
        private int lenghtOfLap;
        private List<Car> cars;
        private List<Thread> threads = new List<Thread>();
        private static int position = 0;
        public static int Position
        {
            get { return position; }
            set { position = value; }
        }
        public Race(int lenghtOfLap, List<Car> cars)
        {
            this.lenghtOfLap = lenghtOfLap;
            this.cars = cars;
        }
        public void SimulateRace()
        {
            foreach (Car car in cars)
            {
                threads.Add(new Thread(() => car.SimulateDrive(lenghtOfLap)));
                threads.Last().Start();
            }
        }
    }
}
