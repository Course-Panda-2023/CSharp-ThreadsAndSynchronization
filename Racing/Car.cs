using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Racing
{
    internal class Car
    {
        private string _name;
        private int _velocity;
        private int _maxPassengers;

        private int _currLap;
        private int _numOfLaps;

        private int _maxFuel;
        private int _currFuel;

        private int _currLocation;

        private static object _key = new object();
        private static object _winnerKey = new object();


        public Car(string name, int velocity, int maxPassengers, int passengers, int maxFuel)
        {
            _name = name;
            _velocity = velocity;
            _maxPassengers = maxPassengers;
            _numOfLaps = (int)Math.Ceiling((double)passengers/ (double)maxPassengers);
            _maxFuel = maxFuel;
            _currFuel = maxFuel;
            _currLap = 1;
            _currLocation = 0;

            Console.WriteLine($"{_name} : laps {_numOfLaps}");
        }

        public void refuel()
        {
            lock (_key)
            {
                Console.WriteLine(_name + " Is Fueling...");
                _currFuel = _maxFuel;
            }
        }

        public void drive(int lap_length)
        {
            int distance = lap_length * _numOfLaps;
            while (_currLocation < distance)
            {
                Console.WriteLine(_name + " Current Location: " + _currLocation + ", Remaining To Finish: " + (distance - _currLocation));
                if (_currFuel == 0)
                    refuel();
                else
                {
                    if (_velocity <= _currFuel)
                    {
                        if(_currLocation + _velocity > distance)
                        {
                            _currLocation = distance;
                        }
                        else
                        {
                            _currLocation += _velocity;
                            _currFuel -= _velocity;
                            if(_currLocation % lap_length < _velocity)
                            {
                                Console.WriteLine(_name + " Finished Lap Number: " + _currLap);
                                _currLap++;
                            }
                        }
                    }
                    else
                    {
                        if (_currLocation + _currFuel > distance)
                        {
                            _currLocation = distance;
                        }
                        else
                        {
                            _currLocation += _currFuel;
                            if (_currLocation % lap_length < _currFuel)
                            {
                                Console.WriteLine(_name + " Finished Lap Number: " + _currLap);
                                _currLap++;
                            }
                            _currFuel = 0;
                        }
                    }
                }

                Thread.Sleep(1000);
            }

            lock (_winnerKey)
            {
                Race.Place ++;
                Console.WriteLine("\n\n******************* " + _name + " Finished In " + Race.Place + "!  *******************\n\n");
            }

        }
    }
}
