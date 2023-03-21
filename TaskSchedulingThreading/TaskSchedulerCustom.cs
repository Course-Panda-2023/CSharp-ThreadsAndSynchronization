namespace TaskSchedulingThreading
{
    internal class TaskSchedulerCustom<T, V>
    {

        private List<Task<T>> tasks = new();

        private void AddTask(Task<T> newTask)
        {
            tasks.Add(newTask);
        }

        public void AddTasks(params Task<T>[] tasks)
        {
            foreach (var task in tasks)
            {
                AddTask(task);
            }
        }

        public void RemoveTask(Task<T> task)
        {
            tasks.Remove(task);
        }

        public void RemoveTasks()
        {
            foreach (var task in tasks)
            {
                RemoveTask(task);
            }
        }

        public void Execute()
        {
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("\n\nSuccessful completion.");
        }
    }
}

