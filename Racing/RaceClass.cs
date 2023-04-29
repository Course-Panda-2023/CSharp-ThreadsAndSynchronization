using Racing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    class RaceClass
    {

        /// <summary>
        /// returns a suffix for 'num' based on it's last digit
        /// </summary>
        /// <param name="num"></param>
        /// <returns>1:"st" 2:"nd" 3:"rd" else:"th"</returns>
        public static string NumSuffix(int num)
        {
            int last_dig = num % 10;
            return ((last_dig == 1) ? "st" : ((last_dig == 2) ? "nd" : ((last_dig == 3) ? "rd" : "th")));
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="cars">array of all cars</param>
        /// <param name="trackLength">the lengh of 1 lap of the track in meters</param>
        /// <param name="passengers"> number of people who need (in total) to complete the race per car</param>
        public static void RunRace(CarClass[] cars,double trackLength ,int passengers = 1)
        {
            Task[] tasks= new Task[cars.Length];
            for (int i=0; i<cars.Length; i++)
            {
                Func<CarClass, Task> f = ((c) => new Task (() => c.Race(trackLength, passengers)));
                tasks[i] =f(cars[i]);
            };

            
            // Start all tasks at once
            foreach (var task in tasks)
            {
                task.Start();
            }
            
            // Wait for any task to complete
            int index = Task.WaitAny(tasks);
            Task.WaitAll(tasks);
            Console.WriteLine($"Race completed! {cars[index].name} won!");
        }
    }
}

