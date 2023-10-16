// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PerformanceAssessment_1
{
    /// <summary>
    /// Class that holds the employee details.
    /// </summary>
    internal class Employee
    {
        private Loggers logger = new Loggers();
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">Name of the employee.</param>
        /// <param name="workingHours">Working hours of the employee.</param>
        /// <param name="availability">Availability of the employee.</param>
        /// <param name="skills">Skills of the Employee.</param>
        public Employee(string name, string workingHours, string skills, string availability)
        {
            this.Name = name;
            int.TryParse(workingHours, out int result);
            this.WorkingHours = result;
            this.Availability = availability.Equals("true", StringComparison.OrdinalIgnoreCase);
            this.Skills = skills;
            allocatedTime = 0;
        }

        /// <summary>
        /// Gets name of the Employee.
        /// </summary>
        /// <value>
        /// Name of the Employee.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets Working hours of the Employee.
        /// </summary>
        /// <value>
        /// Working hours of the Employee.
        /// </value>
        public int WorkingHours { get; }

        /// <summary>
        /// Gets Availability of the Employee.
        /// </summary>
        /// <value>
        /// Availability of the Employee.
        /// </value>
        public bool Availability { get; set; }

        /// <summary>
        /// Gets Skills of the Employee.
        /// </summary>
        /// <value>
        /// Skills of the Employee.
        /// </value>
        public string Skills { get; }

        public int allocatedTime
        {
            get { return allocatedTime; }

            set
            {
                if (value <= 0 && !Availability)
                {
                    this.Availability = true;
                    logger.Log($"{this.Name} has completed the task and free.", 1);
                }
            }
        }
    }
}