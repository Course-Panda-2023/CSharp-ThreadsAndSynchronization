using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduling
{
    public class Tasks <T, V>
    {
        private Func<T, V> task;
        private T parameter;

        public Func<T, V> Task { get { return task; } }
        public T Parameter { get { return parameter; } }

        public Tasks (Func<T, V> task, T parameter)
        {
            this.task = task;
            this.parameter = parameter;
        }
    }
}
