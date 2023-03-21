using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Car
    {
        private string name;
        private int maxSpeed;
        private double acceleration;
        private int passengerAmount;
        private int gasInTank;
        private int metersPassed;
        private int currentSpeed;
        private int lapCounter;
        private bool won;

        public string Name { get { return name; } }
        public int MaxSpeed { get { return maxSpeed; } }
        public double Acceleration { get { return acceleration; } }
        public int PassengerAmount { get { return passengerAmount; } }
        public int GasInTank { get { return gasInTank; } set { gasInTank = value; } }
        public int MetersPassed { get { return metersPassed; } set { metersPassed = value; } }
        public int CurrentSpeed { get { return currentSpeed; } set { currentSpeed = value; } }
        public int LapCounter { get { return lapCounter; } set { lapCounter = value; } }
        public bool Won { get { return won; } set { won = value; } }


        public Car (string name, int maxSpeed, double acceleration, int passengerAmount, int gasTankSize)
        {
            this.name = name;
            this.maxSpeed = maxSpeed;
            this.acceleration = acceleration;
            this.passengerAmount = passengerAmount;
            gasInTank = gasTankSize;
            metersPassed = 0;
            currentSpeed = 0;
            lapCounter = 1;
            won = false;
        }
    }
}
