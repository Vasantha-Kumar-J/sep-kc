namespace EmployeeManager
{
    /// <summary>
    /// Implements methods to schedule 
    /// </summary>
    internal class Scheduler
    {
        /// <summary>
        /// Tasks assigned to employees.
        /// </summary>
        private Dictionary<KeyValuePair<Employee, Task>, int> _tasksAssigned;

        /// <summary>
        /// Initializes a new instance of <see cref="Scheduler"/> with no tasks assigned.
        /// </summary>
        public Scheduler() 
        {
            _tasksAssigned = new Dictionary<KeyValuePair<Employee, Task>, int>();
        }

        /// <summary>
        /// Schedules the time table for employees.
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="tasks"></param>
        public Dictionary<KeyValuePair<Employee, Task>, int> Schedule(List<Employee> employees, List<Task> tasks) 
        {
            _tasksAssigned.Clear();
            List<Task> orderedTasks = tasks.OrderBy(task => task.Deadline).ToList();

            foreach (Task task in orderedTasks)
            {
                foreach (Employee employee in employees)
                {
                    if (task.RequiredHours == 0)
                    {
                        continue;
                    }

                    if (employee.Skills.Contains(task.SkillNeeded) && employee.IsAvailable)
                    {
                        AssignTask(employee, task);
                    }
                }
            }

            return _tasksAssigned;
        }

        /// <summary>
        /// Assigns a task to the employee.
        /// </summary>
        /// <param name="employee">Employee.</param>
        /// <param name="task">Task.</param>
        public void AssignTask(Employee employee, Task task) 
        {
            int hoursAssigned;
            if (employee.WorkingHours > task.RequiredHours)
            {
                hoursAssigned = task.RequiredHours;
            } 
            else
            {
                hoursAssigned = employee.WorkingHours;
            }

            employee.WorkingHours -= hoursAssigned;
            task.RequiredHours -= hoursAssigned;
            if (employee.WorkingHours == 0)
            {
                employee.IsAvailable = false;
            }

            _tasksAssigned.Add(new KeyValuePair<Employee, Task>(employee, task), hoursAssigned);
        }

        /// <summary>
        /// Gets the tasks that are not assigned to any employees.
        /// </summary>
        /// <param name="tasks">Tasks.</param>
        /// <returns>Not assigned tasks.</returns>
        public List<Task> NotAssignedTasks(List<Task> tasks)
        {
            List<Task> notAssignedTasks = new List<Task>();
            foreach (Task task in tasks)
            {
                foreach (var assignedTask in _tasksAssigned)
                {
                    if (task.Id == assignedTask.Key.Value.Id)
                    {
                        break;
                    }
                }
                notAssignedTasks.Add(task);
            }

            return notAssignedTasks;
        }
    }
}
