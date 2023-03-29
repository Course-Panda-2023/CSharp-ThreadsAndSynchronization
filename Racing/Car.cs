
class Car
{
    public string Name {get; set;}
    public int MaxVelocity {get; set;}
    public int Acceleration {get; set;}
    public int Capacity {get; set;}
    public int MaxFuel {get; set;}
    public int RemainingFuel {get; set;}

    public Car(string Name, int MaxVelocity, int Acceleration, int Capacity, int MaxFuel)
    {
        this.Name = Name;
        this.MaxVelocity = MaxVelocity;
        this.Acceleration = Acceleration;
        this.Capacity = Capacity;
        this.MaxFuel = MaxFuel;
        this.RemainingFuel = MaxFuel; // I'm assuming max fuel upon start
    }



}