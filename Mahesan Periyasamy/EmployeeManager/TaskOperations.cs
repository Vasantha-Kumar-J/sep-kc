namespace EmployeeManager
{
    /// <summary>
    /// Implements methods for task operations.
    /// </summary>
    internal class TaskOperations
    {
        /// <summary>
        /// List of tasks.
        /// </summary>
        private readonly List<Task> _tasks;

        /// <summary>
        /// Initializes a new instance of <see cref="TaskOperations"/> with no tasks.
        /// </summary>
        public TaskOperations()
        {
            _tasks = new List<Task>();
        }

        /// <summary>
        /// Adds a task to the collection.
        /// </summary>
        /// <param name="task"></param>
        /// <returns><see langword="true"/>, if the task Id is unique and added successfully; otherwise <see langword="false"/>.</returns>
        public bool AddTask(Task task) 
        {
            foreach (Task task2 in _tasks)
            {
                if (task2.Id == task.Id)
                {
                    return false;
                }
            }
            
            _tasks.Add(task);
            return true;
        }

        /// <summary>
        /// Removes the task from the collection, if present.
        /// </summary>
        /// <param name="taskId">Task Id.</param>
        /// <returns><see langword="true"/>, if the task is successfully removed; otherwise <see langword="false"/>.</returns>
        public bool TryRemoveTask(int taskId) 
        {
            foreach (Task task in _tasks)
            {
                if (task.Id == taskId)
                {
                    return _tasks.Remove(task);
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the tasks collection.
        /// </summary>
        /// <returns>Tasks.</returns>
        public IEnumerable<Task> GetTasks()
        {
            return _tasks.ToList();
        }
    }
}
