using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    internal class Race
    {
        public List<Car> cars;
        public float LengthOfRace;

        public Race(float lengthOfRace)
        {
            cars = new List<Car>();
            LengthOfRace = lengthOfRace;
        }
    }
}
