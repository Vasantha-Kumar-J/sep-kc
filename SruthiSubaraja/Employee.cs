// <copyright file="Employee.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Details of employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="id">ID of the employee</param>
        /// <param name="name">Name of the employee</param>
        /// <param name="skills">Skills of the employee</param>
        /// <param name="workinghours">Working hours of the employee</param>
        public Employee(int id, string name, string[] skills, int workinghours)
        {
            this.Id = id;
            this.Name = name;
            this.Skill = skills;
            this.Availability = true;
            this.WorkingHours = workinghours;
        }

        /// <summary>
        /// Gets ID of the employee.
        /// </summary>
        /// <value>ID of the employee.</value>
        public int Id { get; init; }

        /// <summary>
        /// Gets name of the employee.
        /// </summary>
        /// <value>Name of the employee.</value>
        public string Name { get; init; }

        /// <summary>
        /// Gets or sets skills of the employee.
        /// </summary>
        /// <value>Skill of the employee.</value>
        public string[] Skill { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether employee is available.
        /// </summary>
        /// <value>Availability of the employee</value>
        public bool Availability { get; set; }

        /// <summary>
        /// Gets or sets working hours of employee.
        /// </summary>
        /// <value>Working hours of the employee.</value>
        public int WorkingHours { get; set; }
    }
}
