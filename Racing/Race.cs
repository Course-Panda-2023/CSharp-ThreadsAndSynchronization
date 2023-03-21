using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Racing
{
    public class Race
    {
        static object obj;
        const int GasTankSize = 15;
        const int RaceTrackLength = 200;

        private static int count;
        static int place = 1;

        public Race()
        {
            obj = new object();
            count = 0;
        }

        public void StartRace(object obj)
        {
            Car car = (Car)obj;

            while (!car.Won)
            {
                ChangeSpeed(car);
                UpdateMetersPassed(car);


                if (car.GasInTank <= 0)
                {
                    FillGas(car);
                }

                int metersFromStart = RaceTrackLength * car.PassengerAmount;
                if (metersFromStart - car.MetersPassed <= 0)
                {
                    car.Won = true;
                    break;
                }
                PrintCarInfo(car);

                count++;
                Thread.Sleep(500);
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"Car {car.Name} WON at place: {place}");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");

            place++;
        }

        public void UpdateMetersPassed(Car c)
        {
            const int MetersPerLiter = 5;

            int currentMetersPassed = count * c.CurrentSpeed;
            c.GasInTank -= currentMetersPassed / MetersPerLiter;
            c.MetersPassed += currentMetersPassed;
            if (c.MetersPassed % MetersPerLiter == 0)
            {
                c.GasInTank--;
            }
        }

        public void ChangeSpeed(Car c)
        {
            int updatedSpeed = (int)(c.CurrentSpeed + c.Acceleration);
            if (c.MaxSpeed < updatedSpeed)
            {
                c.CurrentSpeed = c.MaxSpeed;
            }
            else
            {
                c.CurrentSpeed = updatedSpeed;
            }
        }

        public void PrintCarInfo(Car car)
        {
            lock (obj)
            {
                int metersFromStart = RaceTrackLength * car.PassengerAmount;
                car.LapCounter = (car.MetersPassed / RaceTrackLength) + 1;

                Console.WriteLine($"Car {car.Name} info:");
                Console.WriteLine($"    Speed: {car.CurrentSpeed}");
                Console.WriteLine($"    Location: {car.MetersPassed % RaceTrackLength}");
                Console.WriteLine($"    Meters left to finish line: {metersFromStart - car.MetersPassed}");
                Console.WriteLine($"    Lap Number: {car.LapCounter}");
                Console.WriteLine("----------------------------------------");
            }
        }
        public void FillGas(Car c)
        {
            lock (obj)
            {
                c.GasInTank = GasTankSize;
                c.CurrentSpeed = 0;
            }
            Thread.Sleep(5000);
        }

        public void Run()
        {
            List<Car> carList = new List<Car>();
            int input = 0;
            while(input != -1)
            {
                Console.WriteLine("\nEnter 1 to add car");
                Console.WriteLine("Enter -1 to start race");
                input = Convert.ToInt32(Console.ReadLine());
                if(input == 1)
                {
                    Console.WriteLine("Enter car's name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter car's maximum speed:");
                    int maxSpeed = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car's acceleration:");
                    int acceleration = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car's passenger amount:");
                    int passengerAmount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car's gas tank size:");
                    int gasTankSize = Convert.ToInt32(Console.ReadLine());

                    Car c = new Car(name, maxSpeed, acceleration, passengerAmount, gasTankSize);
                    carList.Add(c);
                }
            }
            foreach(Car car in carList)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(StartRace, car);
            }
        }
    }
}
