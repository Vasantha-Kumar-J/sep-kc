using System.Reflection.Metadata;

namespace EmployeeTaskScheduler
{
    /// <summary>
    /// Employee class to store attributes of the employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// List of employees.
        /// </summary>
        public static List<Employee> Employees { get; set; } = new List<Employee>();

        /// <summary>
        /// Name of the employee.
        /// </summary>
        public string EmployeeName { get; set; } = string.Empty;

        /// <summary>
        /// Working hours prefered by the employee.
        /// </summary>
        public double WorkingHours { get; set; }
        
        /// <summary>
        /// Skills specialised by the employee.
        /// </summary>
        public string Skills { get; set; } = string.Empty;

        /// <summary>
        /// Choices for availability list.
        /// </summary>
        public List<string> Availability { get; set; } = new List<string>() { "yes", "no"};

        /// <summary>
        /// Availability status of current employee.
        /// </summary>
        public string AvailabilityOfEmployee { get; set; } = string.Empty;
    }
}