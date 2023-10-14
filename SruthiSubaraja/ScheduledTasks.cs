// <copyright file="ScheduledTasks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Maintains all the tasks that are scheduled
    /// </summary>
    public class ScheduledTasks
    {
        /// <summary>
        /// Gets or sets ID of the tasks that is scheduled.
        /// </summary>
        /// <value>ID of a task.</value>
        public int TaskID { get; set; }

        /// <summary>
        /// Gets or sets a list of employee working on the task.
        /// </summary>
        /// <value>List of Employee ID.</value>
        public List<int> EmployeeIDs { get; set; } = new List<int>();
    }
}
