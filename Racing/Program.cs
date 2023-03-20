using Racing;

internal class Program
{
    private static void Main(string[] args)
    {
        Car c1 = new Car("mazda", 80, 50, 4, 10);
        Car c2 = new Car("toyota", 100, 30, 1, 8);
        c1.Drive(100, 5);
        c2.Drive(100, 2);
    }
}