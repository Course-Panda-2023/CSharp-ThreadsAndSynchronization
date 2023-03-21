using CarRace;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

Tank tank = new()
{
    Fuel = 300
};

List<Car> cars = new(); 

var filename = "cars.xml";
var currentDirectory = Directory.GetCurrentDirectory();
var fullPath = Path.Combine(currentDirectory, filename);

XElement carsXML = XElement.Load(fullPath);

cars = carsXML.Descendants("car").Select(car =>
    new Car()
    {
        Name = car?.Element("name")?.Value,
        MaximumVelocity = Convert.ToUInt16(car?.Element("maximum-velocity")?.Value),
        PassengerCapacity = Convert.ToUInt16(car?.Element("passengers-capacity")?.Value),
        Tank = tank
    }).ToList();

CarsStatic.Cars = cars;


Race race = new()
{
    Meters = 10000
};

race.Init();

var tasks = new List<Task>();

for (int index = 0; index < cars.Count - 1; ++index)
{
    tasks.Add(Task.Run(() => cars[index].DoRandomStep()));
    ThreadPool.QueueUserWorkItem((obj) => cars[index].DoRandomStep(), (object) index);
}

Task.WaitAll(tasks.ToArray());

race.Processing();


Thread.Sleep(1000);

Console.ReadLine();