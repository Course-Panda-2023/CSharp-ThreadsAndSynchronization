using CarRace;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

Tank tank = new Tank()
{
    Fuel = 300
};

Car car = new()
{
    Name = "Cx-6",
    MaximumVelocity = 210,
    PassengerCapacity = 8,
    Tank = tank
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


foreach (Car carn in cars)
{
    Console.WriteLine(carn);
}

Console.ReadLine();