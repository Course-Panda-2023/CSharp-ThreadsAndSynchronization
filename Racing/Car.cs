using System;
using System.Threading;

namespace Racing
{
    internal class Car
    {
        public string CarName { get; set; }
        public float MaxSpeed { get; set; }
        public double MaxFuel { get; set; }
        public double CurrentFuel { get; set; }
        public float Acceleration { get; set; }
        public int MaxPassengers { get; set; }
        private static int NumOfPlace = 1;

        public Car(string carName, float maxSpeed, float acceleration, int maxPassengers, double maxFuel)
        {
            CarName = carName;
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            MaxPassengers = maxPassengers;
            MaxFuel = maxFuel;
            CurrentFuel = MaxFuel;
        }

        public void Drive(float distance, int numofpassengers) // distance is in km
        {
            float currentSpeed = 0.0f;
            float acceleration = MaxSpeed / 30.0f; // assuming 30 steps to reach MaxSpeed
            double fuelConsumptionPerUnitDistance;
            Console.WriteLine($"{CarName} is starting the race with {MaxPassengers} passengers and {CurrentFuel}L of fuel.");
            Thread drivingThread = new Thread(() =>
            {
                int PassengersEachRound = numofpassengers / MaxPassengers;
                int PassengersRemainder = numofpassengers % MaxPassengers;
                int currentRound;
                for (currentRound = 0; currentRound < PassengersEachRound; currentRound++)
                {
                    Console.WriteLine($"{CarName} is currently at round {currentRound + 1} driving {PassengersEachRound} passengers");
                    ThreadSimulateDriving(distance, ref currentSpeed, ref acceleration);
                }
                if(PassengersRemainder != 0)
                {
                    Console.WriteLine($"{CarName} is driving the last {PassengersRemainder} passengers at round {currentRound + 1}");
                    ThreadSimulateDriving(distance, ref currentSpeed, ref acceleration);
                }
                if (CurrentFuel > 0)
                {
                    Console.WriteLine($"{CarName} finished the race with {Math.Round(CurrentFuel)}L of fuel.");
                    Console.WriteLine($"{CarName} finished the race at place {NumOfPlace}");
                    NumOfPlace++;
                }
            });
            drivingThread.Start();
        }
        private void ThreadSimulateDriving(float distance, ref float currentSpeed, ref float acceleration)
        {
            double fuelConsumptionPerUnitDistance;
            for (float i = 0; i <= distance; i++)
            {
                if (CurrentFuel <= 0)
                {
                    Console.WriteLine($"{CarName} ran out of fuel at {i} km.");
                    Refuel();
                    i += 1;
                    currentSpeed = 0.0f;
                    acceleration = MaxSpeed / 30.0f;
                }
                fuelConsumptionPerUnitDistance = (float)(new Random().NextDouble() * 0.15 + 0.01);
                CurrentFuel -= fuelConsumptionPerUnitDistance;
                currentSpeed += acceleration;
                if (currentSpeed > MaxSpeed)
                {
                    currentSpeed = MaxSpeed;
                }
                float drivingTime = distance / currentSpeed * 60.0f; // assuming distance unit is km and speed unit is km/h
                Thread.Sleep((int)Math.Round(drivingTime)); // simulate driving time
                Console.WriteLine("{0}'s current location is {1}km into {2} with fuel {3}L and speed of {4}km/h", CarName, i, distance, Math.Round(CurrentFuel, 2), Math.Round(currentSpeed));

            }
            Console.WriteLine($"{CarName} finished the round with all passengers delivered");
            acceleration = MaxSpeed / 30.0f; // reset acceleration and currentSpeed at end of round
            currentSpeed = 0.0f;
        }
        
        public void Refuel()
        {
            Console.WriteLine($"{CarName} is refueling...");
            Thread.Sleep(new Random().Next(5000, 10000)); // simulate refueling time
            CurrentFuel = MaxFuel;
            Console.WriteLine($"{CarName} has finished refueling with {MaxFuel}L of fuel.");
        }
    }
}
