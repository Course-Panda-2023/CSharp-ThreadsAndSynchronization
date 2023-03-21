using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace CarRace
{
    struct CarRaceStatus
    {
        public Car CarInRace { get; set; }

        public double? KilometersPassed { get; set; }
    }

    internal class Race
    {
        public double? AreaLongMeters = 8800;

        System.Timers.Timer timer = new(1000);


        public void Init() 
        { 
            foreach (Car car in CarsStatic.Cars!)
            {
                CarsStatic.CarRaceStatus?.Add(new CarRace.CarRaceStatus() { CarInRace = car, KilometersPassed = 0 });
            }
        }

        public void Processing()
        {
            for (int i = 0; i < CarsStatic.CarRaceStatus.Count; i++)
            {
                var status = CarsStatic.CarRaceStatus[i];
                status.KilometersPassed += status.CarInRace.CurrentVelocity + status.CarInRace.Accelaration * status.CarInRace.Accelaration;
                CarsStatic.CarRaceStatus[i] = status;
            }

            CarsStatic.Cars.Clear();
            foreach (CarRaceStatus carRaceStatus in CarsStatic.CarRaceStatus)
            {
                CarsStatic.Cars.Add(carRaceStatus.CarInRace);
            }
        }


    }
}
