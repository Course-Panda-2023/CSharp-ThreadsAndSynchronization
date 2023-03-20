using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public class Task_Scheduler
{
    private DateTime startTime;
    private int elapsedSeconds;
    private List<MyTask> taskList;

    public Task_Scheduler()
    {
        startTime = DateTime.Now;
        elapsedSeconds = 0;

        Thread t = new Thread(new ThreadStart(UpdateElapsedSeconds));
        t.Start();

        taskList = new List<MyTask>();
    }

    public int ElapsedSeconds
    {
        get { return elapsedSeconds; }
    }

    public event EventHandler ElapsedSecondsChanged;

    private void UpdateElapsedSeconds()
    {
        while (true)
        {
            int oldElapsedSeconds = elapsedSeconds;
            elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;

            if (elapsedSeconds != oldElapsedSeconds)
            {
                ElapsedSecondsChanged?.Invoke(this, EventArgs.Empty);
            }

            Thread.Sleep(1000);
        }
    }

    public MyTask AddToTaskList()
    {
        MyTask t;
        Console.WriteLine("adding new task");
        Console.WriteLine("");

        // Subscribe to the ElapsedSecondsChanged event
        ElapsedSecondsChanged += (sender, e) =>
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine("at what time do you want your task? current time: {0}", ElapsedSeconds);
        };
        Console.WriteLine("at what time do you want your task? current time: {0}", ElapsedSeconds);
        int time = int.Parse(Console.ReadLine());
        ElapsedSecondsChanged = null;
        if (time > this.ElapsedSeconds)
        {
            Console.WriteLine("name of your task?: ");
            string name = Console.ReadLine();
            bool iscomplete = false;
            t = new MyTask(name, time, iscomplete);
            taskList.Add(t);
        }
        else
        {
            throw new Exception("cant add tasks to the past");
        }
        return t;
    }
    public void RemoveFromTaskList(int id)
    {
        if (!(this.taskList[id].IsCompleted))
        {
            taskList.RemoveAt(id);
            Console.WriteLine("removal successful");
            return;
        }
        Console.WriteLine("too late... already completed");
    }

    public void MarkMissionAsComplete(int id)
    {
        if (this.taskList[id].TaskTime > ElapsedSeconds)
        {
            this.taskList[id].IsCompleted = true;
            Console.WriteLine("marked as completed");
            return;
        }
        Console.WriteLine("too late... complete past time");
    }

    public void PrintAllCurrentTasks()
    {
        for (int i = 0; i < taskList.Count; i++)
        {
            var item = taskList[i];
            Console.WriteLine("id: {0}, task name: {1}, task time: {2}, is complete: {3}", i, item.TaskName, item.TaskTime, item.IsCompleted);
        }
    }
    public void MenuPrompt()
    {
        int input;
        Console.WriteLine("welcome to the task scheduler, what do you want to do?");
        Console.WriteLine("1. add task");
        Console.WriteLine("2. complete task");
        Console.WriteLine("3. remove task");
        Console.WriteLine("current tasks:");
        PrintAllCurrentTasks();
        ElapsedSecondsChanged += (sender, e) =>
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine("current time: {0}", ElapsedSeconds);
        };
        Console.WriteLine("current time: {0}", ElapsedSeconds);
        input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case 1:
                ElapsedSecondsChanged = null;
                AddToTaskList();
                break;
            case 2:
                ElapsedSecondsChanged = null;
                if (taskList.Count != 0)
                {
                    PrintAllCurrentTasks();
                    Console.WriteLine("write in index to complete: ");
                    int inputComplete = int.Parse(Console.ReadLine());
                    MarkMissionAsComplete(inputComplete);
                }
                else
                {
                    Console.WriteLine("empty list");
                }
                break;
            case 3:
                ElapsedSecondsChanged = null;
                if (taskList.Count != 0)
                {
                    PrintAllCurrentTasks();
                    Console.WriteLine("write in index to remove: ");
                    int removalInput = int.Parse(Console.ReadLine());
                    RemoveFromTaskList(removalInput);
                }
                else
                {
                    Console.WriteLine("empty list");
                }
                break;
            default:
                ElapsedSecondsChanged = null;
                Console.WriteLine("invalid input");
                break;
        }
    }
}