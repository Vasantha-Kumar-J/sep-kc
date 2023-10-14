using System.Linq.Expressions;

namespace TaskManager
{
    /// <summary>
    /// Schedules the task
    /// </summary>
    public class TaskScheduler
    {
        /// <summary>
        /// Gets or sets the the assigned tasks as list.
        /// </summary>
        public  List<AssignedTask> ListOfAssignedTask { get; set; } = new List<AssignedTask>();

        /// <summary>
        /// Gets or sets the list of unassignedTasks.
        /// </summary>
        public List<TaskDetails> ListOfUnassignedTask { get; set; } = new List<TaskDetails>();

        /// <summary>
        /// Gets or sets the list of employees without any task assigned.
        /// </summary>
        public List<Employee> ListOfAvailableEmployee { get; set; } = new List<Employee>();


        /// <summary>
        /// Assigns the tasks to the employee.
        /// </summary>
        public void AssignTask() 
        {
            foreach (Employee employee in EmployeeManager.ListOfEmployees)
            {
                foreach (TaskDetails taskDetails in TaskListManager.ListOfSortedTasks)
                {
                    if(taskDetails.RequiredSkills == employee.Skills && (taskDetails.RequiredHours <= employee.WorkingHours * employee.AvailableDays))
                    {
                        AssignedTask assignedTask = new (employee,taskDetails);
                        ListOfAssignedTask.Add(assignedTask);
                        taskDetails.AssignedStatus = true;
                    }
                    else
                    {
                        ListOfAvailableEmployee.Add(employee);
                    }
                }
            }

            foreach(TaskDetails taskDetails in TaskListManager.ListOfSortedTasks)
            {
                if(taskDetails.AssignedStatus == false)
                {
                    ListOfUnassignedTask.Add(taskDetails);
                }
            }
        }
    }
}