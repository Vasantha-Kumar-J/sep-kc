// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    using ConsoleTables;
    using Utility;

    public class EmployeeFunctions
    {
        /// <summary>
        /// Provides various operation to perform in Employee Register.
        /// </summary>
        public static void OperationInEmployeeManagement()
        {
            bool flag = true;
            Dictionary<int, Employee> employees = new();

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Utility.DisplayImportantMessage("Welcome to Employee Register");

            while (flag)
            {
                Console.Write("Enter your operation : \n1- Add Employee\n2- Export Employee details to File\n3- Exit\nEnter your number : ");
                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        AddEmployee(employees);
                        break;
                    case "2":
                        ExportEmployeeDetailsToFile(employees);
                        break;
                    case "3":
                        flag = false;
                        break;
                    default:
                        Utility.DisplayErrorMessage("Please enter proper given operation");
                        break;
                }
            }
        }

        /// <summary>
        /// Add new employee details to the employee dictionary.
        /// </summary>
        /// <param name="employees">Employee Details Dictionary.</param>
        public static void AddEmployee(Dictionary<int, Employee> employees)
        {
            int employeeID;
            Employee employee = new();
            Utility.DisplayImportantMessage("\n To Add Employee");
            employeeID = GetOrValidateInputs.GetValidInputInteger("Enter Employee ID (in numbers) : ");
            employee.SetEmployeeDetails();
            if (employees.ContainsKey(employeeID))
            {
                Utility.DisplayErrorMessage("Employee ID already exits.");
                return;
            }

            employees.Add(employeeID, employee);
            Utility.DisplaySuccessMessage("Employee details added successfully!");
        }

        /// <summary>
        /// Export the employee dictionary to user given text file.
        /// </summary>
        /// <param name="employees">Employee Details Dictionary.</param>
        public static void ExportEmployeeDetailsToFile(Dictionary<int, Employee> employees)
        {
            string filePath = GetOrValidateInputs.GetValidFilePath("Enter your file path to export employee details : ");
            using(var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Employee Details\n");
                var table = new ConsoleTable("Employee ID", "Name", "Working Hours", "Skills", "Available Days");
                foreach (var employee in employees)
                {
                    table.AddRow(employee.Key, employee.Value.Name, employee.Value.WorkingHours, employee.Value.Skill, employee.Value.AvailableDays);
                }

                writer.WriteLine(table);
            }

            Utility.DisplaySuccessMessage("Employee Details written to the file successfully.");
        }
    }

}