using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    internal class Task
    {
        public Task(string taskName, DateTime deadlineDate, bool isCompleted = false)
        {
            this.name = taskName;
            this.deadline = deadlineDate;
            this.isFinished = isCompleted;
            
        }

        public string name;
        public DateTime deadline;
        public bool isFinished;
    }
}
