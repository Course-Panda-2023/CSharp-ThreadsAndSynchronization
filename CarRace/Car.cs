using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    internal class Car
    {
        public string? Name { get; init; }

        public double? MaximumVelocity { get; init; }

        public double? CurrentVelocity { get; set; }

        public double? Accelaration { get; set; }

        public uint? PassengerCapacity { get; init; }

        public Tank? Tank { get; init; }

        private Random random = new();

        public Car() 
        { 
            CurrentVelocity = 0; 
            Accelaration = 0;
        }

        public void DoRandomStep()
        {
            BitVector32 flags = new();

            flags[0] = random.Next(0, 1) == 1;

            double accelartionAbs = random.NextDouble() * 50;

            double accelartion = flags[0] ? accelartionAbs : -accelartionAbs;

            CurrentVelocity += accelartion;

            flags[1] = CurrentVelocity > MaximumVelocity;

            if (flags[1]) CurrentVelocity = MaximumVelocity;

            Accelaration = accelartion;
        }
    }
}
