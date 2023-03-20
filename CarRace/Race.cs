using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    struct CarRaceStatus
    {
        public Car CarInRace { get; set; }

        public double KilometersPassed { get; set; }
    }

    internal class Race
    {
        public List<Car>? Cars { get; init; }

        public double? Kilometers = 8.8;

        private double Second = 1000;

        Timer timer = new(Second);

        public void RaceMonitoring()
        {
            timer.Elapsed += OnTimerTick;
            timer.Start();
            Console.ReadLine();
        }


    }
}
