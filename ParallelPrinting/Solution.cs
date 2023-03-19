using System;

public class Solution
{
    public void Assignment1Part1()
    {
        Task1 taskwithoutbackground = new Task1(false);
        taskwithoutbackground.RunThreads();
    }

    public void Assignment1Part2()
    {
        Task1 taskwithbackground = new Task1(true);
        taskwithbackground.RunThreads();
        //the maximum number of chars printed on background thread
        //is between 0-2 because the program will stop when the main thread (aka the main method) is finished running
        //if the threads were not background they will run normally
    }

    public void Assignment2(string str)
    {
        Task2 t2 = new Task2();
        t2.RunAllThreads(str);
    }

    public void Assignment3Part1(string str)
    {
        Task3 t3 = new Task3();
        t3.RunAllThreads(str, 2);
    }

    public void Assignment3Part2(string str)
    {
        Task3 t3 = new Task3();
        t3.RunAllThreadsByCPU(str);
    }

    public static void Assignment4Part1()
    {
        /*
        * Write code here
        */
    }

    public static void Assignment4Part2()
    {
        /*
        * Write code here
        */
    }
}
