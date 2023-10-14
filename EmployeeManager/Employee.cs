namespace EmployeeManager
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Gets or sets the Id of the employee
        /// </summary>
        /// <value>Id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>Name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the working hours of the employee.
        /// </summary>
        /// <value>Working hours.</value>

        public int WorkingHours { get; set; }

        /// <summary>
        /// Gets or sets the skills of the employee.
        /// </summary>
        /// <value>Skills.</value>
        public List<string> Skills { get; set; }

        /// <summary>
        /// Gets or sets the availability of the employee.
        /// </summary>
        /// <value>Avilability.</value>

        public bool IsAvailable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class with all the attributes set.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="hours">Working hours.</param>
        /// <param name="skills">Skills.</param>
        /// <param name="isAvalilable">Is available,</param>
        public Employee(int id, string name, int hours, List<string> skills, bool isAvalilable)
        {
            Id = id;
            Name = name;
            WorkingHours = hours;
            Skills = skills;
            IsAvailable = isAvalilable;
        }
    }
}
