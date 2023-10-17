using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAndTaskScheduler
{
    internal class Employee
    {
        /// <summary>
        /// Initialize the Employee Class
        /// </summary>
        /// <param name="employeeName">Name of the Employee</param>
        /// <param name="workingHours">Working Hours of the Employee</param>
        /// <param name="skills">Skills of the Employee</param>
        /// <param name="availability">Availability of the Employee</param>
        public Employee(string employeeName, string workingHours, string skills, string availability)
        {
            this.employeeName = employeeName;
            if(int.TryParse(workingHours, out int value))
            {
                this.workingHours = value;
            }
            else
            {
                Console.WriteLine($"Invalid Working Hours in {employeeName}");
            }
            string trimmedString = skills.Trim();
            string[] skillList = trimmedString.Substring(1, trimmedString.Length - 2).Split("/");
            this.skills = new List<string>(skillList);
            this.availability = Convert.ToBoolean(availability);
        }
        /// <summary>
        /// Name of the Employee
        /// </summary>
        public string employeeName{ get; set; }
        /// <summary>
        /// Working Hours of the Employee
        /// </summary>
        public int workingHours { get; set; }
        /// <summary>
        /// List of the skills of the employee
        /// </summary>
        public List<string> skills { get; set; }
        /// <summary>
        /// Availability of the Employee
        /// </summary>
        public bool availability { get; set; }
        /// <summary>
        /// Overrides the toString method in object class
        /// </summary>
        /// <returns>result to be printed</returns>
        public override string ToString()
        {
            return $"Employee Name: {this.employeeName}, Working Hours: {this.workingHours}, Skills: {string.Join(",", this.skills.ToArray())}, Availability: {this.availability}";
        }
    }
}
