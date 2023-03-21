using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Threads
{
    public class Car
    {
        private string name;
        private int speed;
        private int maxNumberOfPassengers;
        private int numberOfPassengers;
        private int currentLap;
        private int currentFuel;
        private int maxFuel;
        private int location;
        private int numberOfLapsNeeded;
        private static object positionLock = new object();
        private static object refuelLock = new object();

        public Car(string name, int speed, int maxNumberOfPassengers, int numberOfPassengers, int maxFuel)
        {
            this.name = name;
            this.speed = speed;
            this.maxNumberOfPassengers = maxNumberOfPassengers;
            this.numberOfPassengers = numberOfPassengers;
            this.maxFuel = maxFuel;
            currentFuel = maxFuel;
            location = 0;
            numberOfLapsNeeded = (int)Math.Ceiling((double)numberOfPassengers / (double)maxNumberOfPassengers);
            currentLap = 1;
        }
        public void SimulateRefuel()
        {
            lock (refuelLock)
            {
                Console.WriteLine($"{name} Is Fueling!");
                currentFuel = maxFuel;
            }
        }
        public void SimulateDrive(int lenghtOfLap)
        {
            int lenghtOfRace = lenghtOfLap * numberOfLapsNeeded;
            while (location < lenghtOfRace)
            {
                Console.WriteLine($"{name} Current Location: {location}, Remaining To Finish: {(lenghtOfRace - location)}");
                if (currentFuel <= 1)
                    SimulateRefuel();
                if (speed <= currentFuel)
                    if (location + speed > lenghtOfRace)
                        location = lenghtOfRace;
                    else
                    {
                        location += speed;
                        currentFuel -= speed;
                        if (location % lenghtOfLap < speed)
                        {
                            Console.WriteLine($"{name} Finished Lap Number: {currentLap}");
                            currentLap++;
                        }
                    }
                else
                {
                    if (location + speed > lenghtOfRace)
                        location = lenghtOfRace;
                    else
                    {
                        location += currentFuel;
                        if (location % lenghtOfLap < currentFuel)
                        {
                            Console.WriteLine($"{name} Finished Lap Number {currentLap}");
                            currentLap++;
                        }
                        currentFuel = 0;
                    }
                }
                Thread.Sleep(1500);
            }
            lock (positionLock)
            {
                Race.Position++;
                Console.WriteLine($"{name} Finished The Race In The {Race.Position} Place !!");
            }
        }
    }
}
