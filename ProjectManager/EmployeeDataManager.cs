// <copyright file="EmployeeDataManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;

namespace ProjectManager
{
    public class EmployeeDataManager
    {
        public static List<Employee> EmployeeList = new List<Employee>();
        private static StreamWriter employeeWriter;

        public static void SetupEmployee()
        {
            Employee employeeOne = new ("1323", "Preetz", 8, "Coding", true);
            Employee employeeTwo = new ("1324", "Tom", 7, "Testing", true);
            Employee employeeThree = new ("1325", "Jerry", 5, "Designing", true);

            EmployeeList.Add(employeeOne);
            EmployeeList.Add(employeeTwo);
            EmployeeList.Add(employeeThree);
        }

        public static void CreateEmployeeDetailsFile(string filePath)
        {
            employeeWriter = new StreamWriter(filePath);
            string employeeInfo = string.Empty;
            foreach (Employee employee in EmployeeList)
            {
               employeeInfo += "\nEMPLOYEE ID : " + employee.EmployeeId + "\nEMPLOYEE NAME : " + employee.EmployeeName + "\nWORKING HOURS : " + employee.EmployeeWorkingHours + "\nSKILLS : " + employee.EmployeeSkills + "\nSTATUS : " + employee.EmployeeStatus + "\n\n";
            }

            employeeWriter.Write(employeeInfo);
            employeeWriter.Close();
        }

        public static void ImportEmployeesFromFile(string filePath)
        {
            try
            {
                string[] fileContent = File.ReadAllLines(filePath);
                foreach (string line in fileContent)
                {
                    string[] employeeInfo = line.Split(' ');
                    int.TryParse(employeeInfo[2], out var hours);
                    bool.TryParse(employeeInfo[4], out var availablity);
                    Employee employee = new(employeeInfo[0], employeeInfo[1], hours, employeeInfo[3], availablity);
                    EmployeeList.Add(employee);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void AddNewEmployee(string employeeId, string? employeeName, int employeeWorkingHours, string employeeSkills, bool employeeStatus)
        {
            Employee newEmployee = new (employeeId, employeeName, employeeWorkingHours, employeeSkills, employeeStatus);
            EmployeeList.Add(newEmployee);
            Utility.DisplayMessageInSpecificColor("Employee added successfully!", "Green");
        }
    }
}