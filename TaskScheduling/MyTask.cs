public class MyTask<T, V>
{
    public T TaskFunction { get; set; }
    public int TaskTime { get; set; }
    public bool IsCompleted { get; set; }
    public V Result { get; set; }
    public object[] Parameters { get; set; }

    public MyTask(T taskFunction, int taskTime, params object[] parameters)
    {
        TaskFunction = taskFunction;
        TaskTime = taskTime;
        IsCompleted = false;
        Parameters = parameters;
    }
}
