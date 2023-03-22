using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
public class Solution
{
    public static string Pow2(int num)
    {
        return $"{num} ^ 2 = {Math.Pow(num, 2)}";
    }

    public static string Pow3(int num)
    {
        return $"{num} ^ 3 ={Math.Pow(num, 3)}";
    }

    public static string Sqrt(int num)
    {
        return $"{num} ^ 0.5 ={Math.Sqrt(num)}";
    }

    public static string Hello(int num)
    {
        return $"Hello {num}";
    }

    public static string Bye(int num)
    {
        return $"Bye {num}";
    }
}