using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SevenBoom
{
    const int LIMIT_NUMBER = 200;
    const int SEVEN = 7;
    const int NUMBER_OF_THREADS = 4;

    static Number_7Boom currentNumber;
    public static void ThreadNumber(int remainder)
    {
        while (true)
            lock (currentNumber)
            {
                if (currentNumber.Number >= LIMIT_NUMBER)
                    break;
                if (currentNumber.Number % 4 == remainder)
                {
                    currentNumber.Number++;
                    Console.WriteLine(PrintBoomOrNumber(currentNumber.Number));
                }
            }
    }
    public static string PrintBoomOrNumber(int number)
    {
        if (number % SEVEN == 0 || number.ToString().Contains('7'))
            return "BOOM";
        return number.ToString();
    }
    public static void RunSevenBoom()
    {
        currentNumber = new Number_7Boom();
        Thread t0 = new Thread(() => ThreadNumber(0));
        Thread t1 = new Thread(() => ThreadNumber(1));
        Thread t2 = new Thread(() => ThreadNumber(2));
        Thread t3 = new Thread(() => ThreadNumber(3));
        t0.Start();
        t1.Start();
        t2.Start();
        t3.Start();
    }
}