namespace Employee_Task_Manager
{
    /// <summary>
    /// Represents Scheduler.
    /// </summary>
    public class Scheduler
    {
        /// <summary>
        /// Gets or sets task description.
        /// </summary>
        /// <value>
        /// Task description.
        /// </value>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Gets or sets Required hours to complete the task.
        /// </summary>
        /// <value>
        ///  Required hours.
        /// </value>
        public double RequiredHours { get; set; }

        /// <summary>
        /// Gets or sets deadLine to complete the task.
        /// </summary>
        /// <value>
        /// Deadline.
        /// </value>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets skills to complete the task.
        /// </summary>
        /// <value>
        /// skills.
        /// </value>
        public string Skill { get; set; }

        /// <summary>
        /// Gets or sets list of task Assigned Employee.
        /// </summary>
        /// <value>
        /// List of task Assigned Employee.
        /// </value>
        public List<Employee> TaskAssignedEmployees { get; set; } = new List<Employee>();
    }
}
