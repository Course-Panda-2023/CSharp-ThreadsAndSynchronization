// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Enter number of cars in race");
int numberOfCars = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter number of passengers in race");
int numberOfPassengers = Convert.ToInt32(Console.ReadLine());

List<Car> cars = new List<Car>();
for (int i=0; i<numberOfCars; i++)
{
    Console.WriteLine($"Enter car {i+1}'s details - Name MaxVelocity Acceleration Capacity MaxFuel");
    string [] carInfo = Console.ReadLine().Split(); // get details, assume valid matching info
    string name = carInfo[0]; 
    int maxVelocity = Convert.ToInt32(carInfo[1]);
    int acceleration = Convert.ToInt32(carInfo[2]);
    int capacity = Convert.ToInt32(carInfo[3]);
    int maxFuel = Convert.ToInt32(carInfo[4]);

    cars.Add(new Car(name, maxVelocity, acceleration, capacity, maxFuel)); 
}

Race race = new Race(cars, numberOfPassengers);

race.RunRace();

// example race input
// 2
// 5
// car1 10 2 3 12
// car2 15 1 3 10