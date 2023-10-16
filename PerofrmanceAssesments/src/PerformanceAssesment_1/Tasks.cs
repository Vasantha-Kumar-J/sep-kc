// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PerformanceAssessment_1
{
    /// <summary>
    /// Class that contains the details of the tasks.
    /// </summary>
    internal class Tasks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tasks"/> class.
        /// </summary>
        /// <param name="name">Name of the task.</param>
        /// <param name="description">Description of the task.</param>
        /// <param name="hours">Hours required.</param>
        /// <param name="deadline">Deadline for the task.</param>
        /// <param name="skills">Skills required.</param>
        public Tasks(string name, string description, string hours, string deadline, string skills)
        {
            TaskName = name;
            TaskDescription = description;
            RequiredHours = int.Parse(hours);
            DeadLine = int.Parse(deadline);
            SkillsRequired = skills.Split(',');
            Status = false;
        }

        /// <summary>
        /// Gets name of the task.
        /// </summary>
        /// <value>
        /// Name of the task.
        /// </value>
        public string TaskName { get; }

        /// <summary>
        /// Gets Description of the task.
        /// </summary>
        /// <value>
        /// Description of the task.
        /// </value>
        public string TaskDescription { get; }

        /// <summary>
        /// Gets Required hours of the task.
        /// </summary>
        /// <value>
        /// Required hours of the task.
        /// </value>
        public int RequiredHours { get; }

        /// <summary>
        /// Gets DeadLine of the task.
        /// </summary>
        /// <value>
        /// DeadLine of the task.
        /// </value>
        public int DeadLine { get; }

        /// <summary>
        /// Gets Skills required of the task.
        /// </summary>
        /// <value>
        /// Skills required of the task.
        /// </value>
        public string[] SkillsRequired { get; }

        public bool Status
        {
            get
            {
                return Status;
            }
            set
            {
                if (value)
                {
                    Program.pendingTasks.Remove(this);
                }
            }
        }
    }
}