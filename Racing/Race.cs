using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    internal class Race
    {
        public List<Car> Cars;
        public List<int> PassengersForEach;
        public float LengthOfRace;

        public Race(float lengthOfRace)
        {
            Cars = new List<Car>();
            PassengersForEach = new List<int>();
            LengthOfRace = lengthOfRace;
        }

        public Race(List<Car> cars, float lengthOfRace)
        {
            Cars = cars;
            PassengersForEach = new List<int>();
            LengthOfRace = lengthOfRace;
        }

        private void AddPassengerForCar(int numOfPassengers)
        {
            PassengersForEach.Add(numOfPassengers);
        }

        private void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public void SetupRace()
        {
            Console.WriteLine("starting race setup");
            if (Cars.Count != 0)
            {
                Console.WriteLine("do you want to reset race and setup again?");
                switch (Console.ReadLine())
                {
                    case "yes":
                        ResetRace();
                        break;
                    case "no":
                        return;
                    default:
                        break;
                }
            }
            Console.WriteLine("how many cars do you want to add?");
            int carcount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carcount; i++)
            {
                AddCarFull(i);
            }
            Console.WriteLine("all cars added successfully");
            PrintRaceStatus();
        }

        private void AddCarFull(int i)
        {
            AddCarToRace(i);
            Console.WriteLine("how many passengers?");
            int numOfPassengersI = int.Parse(Console.ReadLine());
            AddPassengerForCar(numOfPassengersI);
            Console.WriteLine("car {0} with {1} passengers to drive added", i + 1, numOfPassengersI);
        }

        private void AddCarToRace(int i)
        {
            string CarNameI;
            float MaxSpeedI;
            float AccelI;
            int MaxPassengersI;
            double MaxFuelI;
            Console.WriteLine("car {0} car name: ", i + 1);
            CarNameI = Console.ReadLine();
            Console.WriteLine("car {0} max speed: ", i + 1);
            MaxSpeedI = float.Parse(Console.ReadLine());
            Console.WriteLine("car {0} accel: ", i + 1);
            AccelI = float.Parse(Console.ReadLine());
            Console.WriteLine("car {0} max passengers: ", i + 1);
            MaxPassengersI = int.Parse(Console.ReadLine());
            Console.WriteLine("car {0} max fuel: ", i + 1);
            MaxFuelI = float.Parse(Console.ReadLine());
            Car c = new Car(CarNameI, MaxSpeedI, AccelI, MaxPassengersI, MaxFuelI);
            AddCar(c);
        }

        public void PrintRaceStatus()
        {
            Console.WriteLine("all cars in race: ");
            for (int i = 0; i < Cars.Count; i++)
            {
                Car CarByIndex = Cars[i];
                Console.WriteLine($"car number {i}, car name: {CarByIndex.CarName}, car max speed: {CarByIndex.MaxSpeed}, " +
                    $"car fuel: {CarByIndex.MaxFuel}L, car acceleration: {CarByIndex.Acceleration}, max passengers: {CarByIndex.MaxPassengers}, " +
                    $"passengers to enter car: {PassengersForEach[i]}");
            }
        }

        public void StartRace()
        {
            if (Cars.Count == 0)
            {
                Console.WriteLine("no participants added, please add participants");
                return;
            }
            Console.WriteLine("starting race in 3...");
            Thread.Sleep(1000);
            Console.WriteLine("starting race in 2...");
            Thread.Sleep(1000);
            Console.WriteLine("starting race in 1...");
            Thread.Sleep(1000);
            Console.WriteLine("GO!!!!!!!!!!!!!!!");
            for (int i = 0; i < Cars.Count; i++)
            {
                Cars[i].Drive(LengthOfRace, PassengersForEach[i]);
            }
            Console.WriteLine("race finished");
        }
        private void ResetRace()
        {
            Cars = null;
            PassengersForEach = null;
            Console.WriteLine("race reset");
        }

        public void RemoveParticipant()
        {
            if (Cars.Count != 0)
            {
                Console.WriteLine("Remove participant");
                Console.WriteLine("Which car to remove?");
                PrintRaceStatus();
                int carNumber = int.Parse(Console.ReadLine());
                Cars.RemoveAt(carNumber);
                PassengersForEach.RemoveAt(carNumber);
            } else
            {
                Console.WriteLine("No participants to remove");
            }

        }
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Setup race");
                Console.WriteLine("2. Reset race");
                Console.WriteLine("3. Start race");
                Console.WriteLine("4. Add participant");
                Console.WriteLine("5. Remove participant");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Race Status:");
                PrintRaceStatus();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SetupRace();
                        break;
                    case "2":
                        ResetRace();
                        break;
                    case "3":
                        StartRace();
                        break;
                    case "4":
                        AddCarFull((int)Cars.Count);
                        break;
                    case "5":
                        RemoveParticipant();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
        }

    }
}
