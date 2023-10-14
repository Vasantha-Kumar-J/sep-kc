namespace TaskManager
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the working hours of the employee per day.
        /// </summary>
        public double WorkingHours { get; set; }

        /// <summary>
        /// Gets or setd the skills of the employee.
        /// </summary>
        public string? Skills { get; set; }

        /// <summary>
        /// Gets or sets the employee Id.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the availability of the employee.
        /// </summary>
        public int AvailableDays {  get; set; }
    }
}