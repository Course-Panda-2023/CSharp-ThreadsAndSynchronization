Car ford = new Car("Ford", 9, 3, 3, 18);
Car toyota = new Car("Toyota", 12, 1, 4, 30);
Car mazda = new Car("Mazda", 6, 1, 1, 40);
Car wolk = new Car("Wolkswagen", 15, 2, 5, 35);
Race r = new Race(30, new List<Car>() { ford, toyota, mazda, wolk });
r.SimulateRace();