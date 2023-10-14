// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TaskScheduler
{
    /// <summary>
    /// Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">String array of arguments.</param>
        public static void Main(string[] args)
        {
            EmployeeAndTaskManager taskManager = new ();
            do
            {
                Console.WriteLine("Task scheduler");
                Console.WriteLine("Enter your choice\n1. Add employee.\n2. Add task.\n3. Write content to file.\n4. Schedule tasks.\n5. Exit.");
                string choice = UserInput.GetValidInput("Enter your choice", "^[1-4]$");
                switch (choice)
                {
                    case "1":
                        taskManager.AddEmployee();
                        break;
                    case "2":
                        taskManager.AddTask();
                        break;
                    case "3":
                        FileWriter fileWriter = new ();
                        fileWriter.WriteToEmployeeFile(taskManager.Employees);
                        fileWriter.WriteToTaskFile(taskManager.Tasks);
                        break;
                    case "4":
                        List<ScheduledTasks> list = new ();
                        ScheduledTasks scheduledTasks = new ();
                        ScheduledTaskManager scheduledTaskManager = new ();
                        scheduledTaskManager.Schedule(taskManager, list, scheduledTasks);
                        break;
                    default:
                        return;
                }
            }
            while (true);
        }
    }
}