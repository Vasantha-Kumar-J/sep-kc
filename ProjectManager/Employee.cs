// <copyright file="Employee.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;

namespace ProjectManager
{
    public class Employee
    {
        public Employee(string employeeId, string? employeeName, int employeeWorkingHours, string employeeSkills, bool employeeStatus)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.EmployeeWorkingHours = employeeWorkingHours;
            this.EmployeeSkills = employeeSkills;
            this.EmployeeStatus = employeeStatus;
            this.Task = string.Empty;
        }

        public string EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public int EmployeeWorkingHours { get; set; }

        public string EmployeeSkills { get; set; }

        public bool EmployeeStatus { get; set; }

        public string Task { get; set; }
    }
}