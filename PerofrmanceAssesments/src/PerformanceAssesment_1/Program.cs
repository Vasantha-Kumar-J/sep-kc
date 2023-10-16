// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.VisualBasic;
using System.Diagnostics;

namespace PerformanceAssessment_1
{
    /// <summary>
    /// Main class where the program starts.
    /// </summary>
    internal class Program
    {
        private static FileHandler _fileHandler = new FileHandler();
        internal static string _docPath = "..\\..\\..\\..\\..\\docs\\Assessment_1";

        /// <summary>
        /// Get and Set List of employees.
        /// </summary>
        /// <value>
        /// List of employees.
        /// </value>
        public static List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Get and Set List of Tasks.
        /// </summary>
        /// <value>
        /// List of Tasks.
        /// </value>
        public static List<Tasks> tasks = new List<Tasks>();

        public static List<Tasks> pendingTasks = new List<Tasks>();

        /// <summary>
        /// Method where the compiler starts its compilation.
        /// Has the User interface oriented codes.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to task manager");

            Scheduler scheduler = new Scheduler();
            Thread timer = new Thread(() => scheduler.Timer());
            timer.Start();

            scheduler.myTimer += DecreaseTime;

            DoBasicSetUp();

            while (pendingTasks.Count > 0)
            {
                foreach (var task in pendingTasks)
                {
                    scheduler.AllocatePersons(task);
                }
                WriteCurrentStatus();
            }
        }

        private static void WriteCurrentStatus()
        {
            string path = Path.Combine(_docPath, "EmployeeStatus.txt");
            File.Delete(path);
            string content = "";
            foreach(var employee in employees)
            {
                content += employee.Name + " - " + employee.WorkingHours.ToString() + " - " + employee.Skills + " - " + employee.Availability+"\n";
            }

            new FileHandler().WriteData(path, content, true) ;
        }

        private static void DecreaseTime()
        {
            foreach (Employee emp in employees)
            {
                if (!emp.Availability)
                {
                    emp.allocatedTime -= 1;
                }
            }
        }

        private static void DoBasicSetUp()
        {
            AddEmployeeToList();
            AddTasksToList();
            AlignTaskBasedOnDeadLines();
        }

        private static void AlignTaskBasedOnDeadLines()
        {
            tasks.Sort((t1, t2) => t1.DeadLine.CompareTo(t2.DeadLine));
        }

        private static void AddTasksToList()
        {
            string[] array = _fileHandler.ReadData(Path.Combine(_docPath, "TaskData.txt")).Split('\n');
            Tasks task;

            foreach (string item in array)
            {
                string[] attributes = item.Split(" - ");
                task = new Tasks(attributes[0].Trim(), attributes[1].Trim(), attributes[2].Trim(), attributes[3].Trim(), attributes[4].Trim());

                tasks.Add(task);
                pendingTasks.Add(task);
            }
        }

        private static void AddEmployeeToList()
        {
            string[] array = _fileHandler.ReadData(Path.Combine(_docPath, "EmployeeData.txt")).Split('\n');

            foreach (string item in array)
            {
                string[] attributes = item.Split("-");
                employees.Add(new Employee(attributes[0].Trim(), attributes[1].Trim(), attributes[2].Trim(), attributes[3].Trim()));
            }
        }
    }
}