// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EmployeeTaskScheduler
{
    using ConsoleTables;
    using System.Threading.Tasks;
    using Utility;

    public class TaskFunctions
    {
        /// <summary>
        /// Provides various operation to perform in Task Register.
        /// </summary>
        public static void OperationInTaskManagement()
        {
            bool flag = true;
            Dictionary<int, Task> tasks = new();

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Utility.DisplayImportantMessage("Welcome to Task Register");

            while (flag)
            {
                Console.Write("Enter your operation : \n1- Add Task\n2- Export task to file\n3- Exit\nEnter your number : ");
                string userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        ExportTaskDetailsToFile(tasks);
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

        public static void AddTask(Dictionary<int, Task> tasks)
        {
            int taskID;
            Task task = new();
            Utility.DisplayImportantMessage("\n To Add Task");
            taskID = GetOrValidateInputs.GetValidInputInteger("Enter Task ID (in numbers) : ");
            task.SetTaskDetails();
            if (tasks.ContainsKey(taskID))
            {
                Utility.DisplayErrorMessage("Task ID already exits.");
                return;
            }

            tasks.Add(taskID, task);
            Utility.DisplaySuccessMessage("Task details added successfully!");
        }

        public static void ExportTaskDetailsToFile(Dictionary<int, Task> tasks)
        {
            string filePath = GetOrValidateInputs.GetValidFilePath("Enter your file path to export task details : ");
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Task Details\n");
                var table = new ConsoleTable("Task ID", "Description", "Required Hours", "Skills", "DeadLine(in days)");
                foreach (var task in tasks)
                {
                    table.AddRow(task.Key, task.Value.Description, task.Value.RequiredHours, string.Join(",", task.Value.NecessarySkills), task.Value.Deadline);
                }

                writer.WriteLine(table);
            }

            Utility.DisplaySuccessMessage("Task Details written to the file successfully.");
        }
    }

}