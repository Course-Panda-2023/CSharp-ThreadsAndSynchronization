using System;

namespace TaskScheduling
{
    public class Solution
    {
        public static string Func1(int num)
        {
            return $"{num} ^ 2 ={Math.Pow(num, 2)}";
        }

        public static string Func2(int num)
        {
            return $"{num} ^ 3 ={Math.Pow(num, 3)}";
        }

        public static string Func3(int num)
        {
            return $"{num} ^ 0.5 ={Math.Sqrt(num)}";
        }

        public static string Func4(int num)
        {
            return $"Hello {num}";
        }

        public static string Func5(int num)
        {
            return $"Bye {num}";
        }
    }
}