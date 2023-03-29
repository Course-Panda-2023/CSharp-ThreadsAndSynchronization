
class Race
{
    List<Car> cars = new List<Car>();
    int PassengerToDrive;
    object FuelingLock = new object();
    
    public Race(List<Car> cars, int PassengerToDrive)
    {
        this.cars = cars;
        this.PassengerToDrive = PassengerToDrive;
    }

    public void RunRace()
    {
        Console.WriteLine("Race is starting!");
        List<Thread> threads = new List<Thread>();
        foreach (Car car in this.cars)
        {
            Thread thread = new Thread(() => CarRace(car));
            threads.Add(thread);
            thread.Start();
        }
    }

    public void CarRace(Car car)
    {
        Console.WriteLine($"Car {car.Name} is off and running.");
        int numberOfLapsLeft = Convert.ToInt32(Math.Ceiling((double)this.PassengerToDrive/car.Capacity));
        int carSpeed = 0;
        int carLocation = 0;
        while (numberOfLapsLeft > 0)
        {
            carSpeed = Math.Min(car.MaxVelocity, carSpeed + car.Acceleration);
            Console.WriteLine($"Car {car.Name} is with velocity of {carSpeed}.");
            if (car.RemainingFuel - carSpeed <= 0)
            {
                carSpeed = 0;
                FuelCar(car);
            }
            car.RemainingFuel-= carSpeed;
            Thread.Sleep(1000);
            carLocation += carSpeed;
            if (carLocation > 10)
            {
                carLocation = carLocation % 10;
            }
            if (numberOfLapsLeft > 0)
                Console.WriteLine($"Car {car.Name} has {numberOfLapsLeft} laps left and is {carLocation}/10 in the lap!");
            
        }
        Console.WriteLine($"Car {car.Name} has finished the race!");
        
    }

    public void FuelCar(Car car) 
    {
        lock(FuelingLock) // lock so fueling is available for 1 car only 
        {
            Console.WriteLine($"Car {car.Name} is fueling.");
            Thread.Sleep(5000); // 5 seconds to refuel
            car.RemainingFuel = car.MaxFuel;
            Console.WriteLine($"Car {car.Name} finished fueling.");
        }
        
    }
}