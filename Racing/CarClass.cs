using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    internal class CarClass
    {
        const double time_interval = 0.01; //in seconds (10 ms)
        readonly static object refuelLock = new();
        readonly internal string name;
        readonly int metersPerFuelTank;
        readonly internal int capacity;
        readonly double acceleration; // (meters/second^2)
        readonly int maxVelocity; //max speed of car (meters/second)
        double currentVelocity; //speed of car (meters/second)
        double fuel;

        public CarClass(string _name, int _maxSpeed, double _acceleration, int _capacity = 1)
        {
            name = _name;
            metersPerFuelTank = 4000;
            maxVelocity = _maxSpeed;
            fuel = metersPerFuelTank;
            capacity = _capacity;
            acceleration = _acceleration;
            currentVelocity = 0.0;
        }
        /// <summary>
        /// refueles a car
        /// </summary>
        /// <remarks>
        /// <para>alows up to 1 car to refuel at a time</para>
        /// <para>holds any more cars in a lock</para>
        /// </remarks>
        public void Refuel()
        {
            currentVelocity= 0.0; // in a real life situation i would also address deceleration
            lock (refuelLock)
            {
                Console.WriteLine(name + " starting refueling");
                Thread.Sleep(5000);
                fuel = metersPerFuelTank;
                Console.WriteLine(name + " finished refueling");
            }
        }

        double TotalDistance = 0;
        int raceLaps = 1;
        double trackLength;
        int currLap;
        internal void Race(double _trackLength, int _passengers) //TODO: finish
        {
            trackLength = _trackLength;
            raceLaps = (int)Math.Ceiling(((double)_passengers / (double)capacity));
            while (true)
            {
                UpdateLocation();
                CheckFuel();
                if (UpdateLaps())
                {
                    Console.WriteLine($"{name} Finished !!!"); //TODO
                    break;
                }
            }
        }

        private void UpdateLocation()//TODO: finish
        {
            double NewVel = GetNewVelocity();

            double distance = ((currentVelocity+NewVel)/2)*time_interval; // ((V+V0)/2)*t
            
            TotalDistance += distance;
            fuel -= distance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>the velocity at end of time interval</returns>
        private double GetNewVelocity()
        {
            return Math.Min(currentVelocity + acceleration, maxVelocity);
        }

        private void CheckFuel()
        {
            if (fuel <= 0) { Refuel(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if finished last lap, false otherwise</returns>
        private bool UpdateLaps()
        {
            int _currLap = (int)(TotalDistance / trackLength) + 1;
            if (_currLap > raceLaps)
            {
                return true;
            }
            if (_currLap != currLap)
            {
                Console.WriteLine($"{name} starting lap {_currLap}");
                currLap = _currLap;
            }
            return false;
        }
    }
}





        /*
            for (int lap = 1; lap <= raceLaps; lap++)
            {
                if (raceLaps == lap)
                    Console.WriteLine($"{name} is on it's {lap}{RaceClass.NumSuffix(lap)} and final lap");
                else
                    Console.WriteLine($"{name} is starting it's {lap}{RaceClass.NumSuffix(lap)} lap");
                DateTime lapStartTime = DateTime.Now;
                Thread.Sleep(1000);




                Console.WriteLine($"{name} took {(DateTime.Now - lapStartTime).TotalSeconds} seconds to complete lap {lap}/{raceLaps}");

            }
        }*/
    

