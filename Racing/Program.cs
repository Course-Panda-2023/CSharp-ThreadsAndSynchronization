// See https://aka.ms/new-console-template for more information
using Racing;
using static Racing.RaceClass;

CarClass car1 = new("car1", 300, 50, 3);
CarClass car2 = new("car2", 300, 50, 4);
CarClass car3 = new("car3", 300, 100);
CarClass car4 = new("car4", 300, 50, 2);
CarClass car5 = new("car5", 300, 50);

CarClass[] cars = { car1, car2, car3, car4, car5 };
RaceClass.RunRace(cars, 4000, 4);