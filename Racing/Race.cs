using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Racing
{
    internal class Race
    {
        private int _lapLength;
        //private static System.Timers.Timer _timer;
        private int _time;
        private List<Car> _cars = new List<Car>();
        private List<Thread> _threads = new List<Thread>();
        private static int _place = 0;
        public static int Place
        {
            get { return _place; }
            set { _place = value; }
        }
        public Race( int lapLength,List<Car> l)
        {
            _time = 0;
            _cars = l;   
            _lapLength = lapLength;
        }
        public void Start()
        {
            foreach (Car car in _cars)
            {
                _threads.Add(new Thread(() => car.drive(_lapLength)));
                _threads.Last().Start();
            }
        }
    }
}
