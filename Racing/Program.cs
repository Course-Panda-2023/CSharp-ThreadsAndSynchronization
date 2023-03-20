// See https://aka.ms/new-console-template for more information


using Racing;

Car c1 = new Car("car1", 10, 2, 4, 20);
Car c2 = new Car("car2", 15, 1, 3, 100);
Car c3 = new Car("car3", 8, 2, 3, 15);
Car c4 = new Car("car4", 9, 4, 4, 16);


Race r = new Race(30,new List<Car>() { c1,c2, c3, c4 });   
r.Start();