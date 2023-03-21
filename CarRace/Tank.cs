using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    internal struct Tank
    {
        public uint CurrentFuel { get; set; }
        public uint Fuel { get; init; }

        public bool IsTankEmapty()
        {
            return Fuel == 0;
        }
    }
}
