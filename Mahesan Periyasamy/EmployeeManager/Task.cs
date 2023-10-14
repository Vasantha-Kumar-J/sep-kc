namespace EmployeeManager
{
    /// <summary>
    /// Represents a task.
    /// </summary>
    internal class Task
    {
        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        /// <value>Id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>Description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the required hours.
        /// </summary>
        /// <value>Required hours.</value>
        public int RequiredHours { get; set; }

        /// <summary>
        /// Gets the date of task created.
        /// </summary>
        /// <value>Date of task created.</value>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets or sets the date of the deadline.
        /// </summary>
        /// <value>Date of the deadline.</value>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the skill needed.
        /// </summary>
        /// <value>Skill needed.</value>
        public string SkillNeeded { get; set; }

        /// <summary>
        /// Initialized a new instance of the <see cref="Task"/> class with all attributes set.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="requiredHours"></param>
        /// <param name="deadline"></param>
        /// <param name="skillNeeded"></param>
        public Task(int id, string description, int requiredHours, DateTime deadline, string skillNeeded)
        {
            Id = id;
            Description = description;
            RequiredHours = requiredHours;
            CreatedAt = DateTime.Now;
            Deadline = deadline;
            SkillNeeded = skillNeeded;
        }
    }
}
