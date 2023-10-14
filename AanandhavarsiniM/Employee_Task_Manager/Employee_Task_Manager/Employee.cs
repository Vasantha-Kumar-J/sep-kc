namespace Employee_Task_Manager
{
    /// <summary>
    /// Represents Employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets name of Employee.
        /// </summary>
        /// <value>
        /// Name of Employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets working hours of employee.
        /// </summary>
        /// <value>
        /// Working hours of Employee.
        /// </value>
        public double WorkingHours { get; set; }

        /// <summary>
        /// Gets or sets availability of employee.
        /// </summary>
        /// <value>
        /// Availability of Employee.
        /// </value>
        public string Availability { get; set; }

        /// <summary>
        /// Gets or sets skill of employee.
        /// </summary>
        /// <value>
        /// Skill of Employee.
        /// </value>
        public string Skill { get; set; }
    }
}
