using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    public const float FuelMax = 1000;
    private const float fuelingSpeed = 100;
    private static object fuelLock;
    public string Name { get; private set; }
    public float MaxSpeed { get; private set; }
    public float Acceleration { get; private set; }
    public int Seats { get; private set; }
    public float? FuelLeft { get; set; }
    public int? LapsNeeded { get; set; }
    public float? Speed { get; set; }
    public float? Position { get; set; }
    public Car(string name, float maxSpeed, float acceleration, int seats)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        Acceleration = acceleration;
        Seats = seats;
        FuelLeft = null;
        LapsNeeded = null;
        Position = null;
        fuelLock = "doesnt matter";
    }
    public void MovePosition() => Position += Speed;
    public void SpeedUp() 
    {
        Speed += Acceleration;
        if (Speed > this.MaxSpeed) { Speed = this.MaxSpeed; }
    }
    public void BurnFuel() => FuelLeft -= Speed;
    public void SaveLapsNeeded(int passengerCount) => LapsNeeded = (int)Math.Ceiling((double)passengerCount / this.Seats);
    public void RefillFuel(int timeUnit)
    {
        this.Speed = 0;
        lock (fuelLock)
        {
            while(FuelLeft < FuelMax)
            {
                Console.WriteLine("Refeuling " + this.ToString());
                FuelLeft += fuelingSpeed;
                Thread.Sleep(timeUnit);
            }
            if (FuelLeft > FuelMax) { FuelLeft = FuelMax; }
            Console.WriteLine(this.Name + " fueled");
            
        }
    }
    public override string ToString()
    {
        string toString = string.Empty;
        toString += $"Car Name: {Name}, Position: {Position}, Speed: {Speed}, ";
        toString += $"Acceleration: {Acceleration}, FuelLeft: {FuelLeft}, FuelMax: {FuelMax}, ";
        toString += $"MaxSpeed: {MaxSpeed}, Seats: {Seats}, LapsNeeded: {LapsNeeded}";
        return toString ;

    }
    public static Car ReadCarStats(int carNum)
    {
        Console.WriteLine("Enter Car " + carNum + " Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Car " + carNum + " Max Speed");
        float maxSpeed = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter Car " + carNum + " Acceleration");
        float acceleration = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter Car " + carNum + " Seats");
        int seats = int.Parse(Console.ReadLine());
        return new Car(name, maxSpeed, acceleration, seats);
    }
}

