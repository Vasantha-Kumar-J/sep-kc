﻿namespace EmployeeTaskScheduler
{
    /// <summary>
    /// Task class to store the attributes of the tasks.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// List of tasks provided.
        /// </summary>
        public static List<Task> Tasks = new List<Task>();

        /// <summary>
        /// Description of the task to be performed.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// RequiredHours to complete the particular task.
        /// </summary>
        public double RequiredHours { get; set; }

        /// <summary>
        /// Deadline date of the Task.
        /// </summary>
        public DateTime DeadlineDate { get; set; }

        /// <summary>
        /// Skills required to complete the task.
        /// </summary>
        public string Skills { get; set; } = string.Empty;

        public bool Assigned { get; set; } = false;
    }
}