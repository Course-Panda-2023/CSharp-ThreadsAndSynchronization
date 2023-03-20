using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    internal class Car
    {
        public string? Name { get; init; }

        public double? MaximumVelocity { get; init; }

        public double CurrentVelocity { get; set; }

        public double? Accelaration { get; set; }

        public uint? PassengerCapacity { get; init; }

        public Tank? Tank { get; init; }
    }
}
