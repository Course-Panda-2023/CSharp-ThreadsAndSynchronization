using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Race
{
    const int TimeUnit = 1000;
    const int Length = 1000;
    private int PassengerCount { get; set; }
    private List<Car> Cars { get; set; }
    private int? StartTime { get; set; }
    public Race()
    {
        this.StartTime = null;
    }
    public void Run()
    {
        ReadRaceStats();
        InitializeRace();
        foreach (Car car in Cars)
        {
            ThreadPool.QueueUserWorkItem(CarThread, car);
            Thread.Sleep((int)(TimeUnit / Cars.Count));
        }

    }
    public void CarThread(object givenCar)
    {
        Car car = (Car)givenCar;
        while (true)
        {

            car.MovePosition();
            car.SpeedUp();
            car.BurnFuel();
            if (car.FuelLeft < 0) { car.RefillFuel(TimeUnit); }
            Console.WriteLine(car.ToString());
            if(car.Position > Length * car.LapsNeeded)
            {
                Console.WriteLine(car.Name + " Finished!");
                Environment.Exit(Environment.ExitCode);
            }
            Thread.Sleep(TimeUnit);
        }
        
        
    }
    public void ReadRaceStats()
    {
        Console.WriteLine("Enter Number of Passengers Each Car will Need to Transport in the Race");
        this.PassengerCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Number of Cars");
        int carCount = int.Parse(Console.ReadLine());
        Cars = new List<Car>();
        for (int i = 0; i < carCount; i++)
        {
            Cars.Add(Car.ReadCarStats(i));
        }

    }
    public void InitializeRace()
    {
        foreach (Car car in Cars)
        {
            car.Speed= 0;
            car.Position= 0;
            car.FuelLeft = Car.FuelMax;
            car.SaveLapsNeeded(this.PassengerCount);

        }
    }
}

