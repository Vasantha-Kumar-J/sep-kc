namespace Employee_Task_Manager
{
    /// <summary>
    /// Represents Task.
    /// </summary>
    public class Task
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
    }
}
