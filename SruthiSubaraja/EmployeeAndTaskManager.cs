// <copyright file="EmployeeAndTaskManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Manages all available tasks and employees.
    /// </summary>
    public class EmployeeAndTaskManager
    {
        /// <summary>
        /// Gets or sets list of employees available.
        /// </summary>
        /// <value>List of employees</value>
        public List<Employee> Employees { get; set; } = new List<Employee>();

        /// <summary>
        /// Gets or sets list of tasks available.
        /// </summary>
        /// <value>List of tasks.</value>
        public List<Task> Tasks { get; set; } = new List<Task>();

        /// <summary>
        /// Add Employee to the database.
        /// </summary>
        public void AddEmployee()
        {
            string employeeName = UserInput.GetValidInput("Enter the employee name", "[a-zA-Z]*($| [a-zA-Z]*)*$");
            string skill = UserInput.GetValidInput("Enter your skills with comma", "[a-zA-Z]*($|,[a-zA-Z]*)$");
            string[] skills = skill.Split(',');
            string workingHour = UserInput.GetValidInput("Enter the working hours of the employee", "^[0-9]*$");
            int workingHours;
            int.TryParse(workingHour, out workingHours);
            Employee employee = new (this.Employees.Count + 1, employeeName, skills, workingHours);
            this.Employees.Add(employee);
        }

        /// <summary>
        /// Add task to the database
        /// </summary>
        public void AddTask()
        {
            string description = UserInput.GetValidInput("Enter description of the task", "^(.*)$");
            string skill = UserInput.GetValidInput("Enter the required skills with comma", "[a-zA-Z]*($|,[a-zA-Z]*)$");
            string[] skills = skill.Split(",");
            string requiredHour = UserInput.GetValidInput("Enter the required hours to complete the task", "^[0-9]+$");
            int requiredHours;
            int.TryParse(requiredHour, out requiredHours);
            string deadline = UserInput.GetValidInput("Enter the deadline example: 12 January 2003", "^(.*)$");
            DateTime deadLineDate = DateTime.Parse(deadline);
            Task task = new (this.Tasks.Count + 1, requiredHours, deadLineDate, description, skills);
            this.Tasks.Add(task);
        }
    }
}
