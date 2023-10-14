namespace TaskManager
{
    /// <summary>
    /// Task assigned to employee
    /// </summary>
    public class AssignedTask
    {
        /// <summary>
        /// Gets or sets the employee object.
        /// </summary>
        public Employee? Employee { get; set; }

        /// <summary>
        /// Gets or sets the taskdetails object.
        /// </summary>
        public TaskDetails? TaskDetails { get; set; }

        public AssignedTask(Employee employee, TaskDetails taskDetails)
        {
            Employee = employee;

            TaskDetails = taskDetails;
        }

    }
}