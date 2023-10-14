// <copyright file="Task.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Maintains all the task available.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        /// <param name="id">ID of the task.</param>
        /// <param name="requiredHours">Hours required to complete the task.</param>
        /// <param name="date">The deadline.</param>
        /// <param name="description">Description about the task.</param>
        /// <param name="skills">Skills required to complete the task</param>
        public Task(int id, int requiredHours, DateTime date, string description, string[] skills)
        {
            this.Id = id;
            this.RequiredHours = requiredHours;
            this.Deadline = date;
            this.Description = description;
            this.Skills = skills;
        }

        /// <summary>
        /// Gets ID of the task.
        /// </summary>
        /// <value>Id of the task.</value>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets description of the task.
        /// </summary>
        /// <value>Description of the task.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets required hours to complete the task.
        /// </summary>
        /// <value>Required hours to complete the task.</value>
        public int RequiredHours { get; set; }

        /// <summary>
        /// Gets or sets deadline of the task.
        /// </summary>
        /// <value>Deadline of the task.</value>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets skills required to complete the task.
        /// </summary>
        /// <value>Skills required for the task.</value>
        public string[] Skills { get; set; }
    }
}
