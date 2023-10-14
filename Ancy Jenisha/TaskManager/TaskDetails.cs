namespace TaskManager
{
    public class TaskDetails
    {
        /// <summary>
        /// Gets or sets the Description of the task.
        /// </summary>
        public string? DescriptionOfTask { get; set; }

        /// <summary>
        /// Gets or sets the hours required for the task.
        /// </summary>
        public int RequiredHours { get; set; }

        /// <summary>
        /// Gets or sets the Deadline of the task.
        /// </summary>
        public int DeadLine { get; set; }

        /// <summary>
        /// Gets or sets the skills required for the task.
        /// </summary>
        public string? RequiredSkills { get; set; }

        /// <summary>
        /// The assignment status of the task.
        /// </summary>
        public bool? AssignedStatus = false;

    }
}