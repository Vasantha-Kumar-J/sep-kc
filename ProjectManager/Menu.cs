// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace ProjectManager
{
    public class Menu
    {
        public static void Start()
        {
            TasksDataManager.SetupTasks();
            EmployeeDataManager.SetupEmployee();
            while (true)
            {
                Utility.DisplayMessageInSpecificColor(
                    "What do you wanna do?" +
                    "\n1.Add Task" +
                    "\n2.Add Employee" +
                    "\n3.Import Tasks from file." +
                    "\n4.Import Employee from file" +
                    "\n5.Export tasks list." +
                    "\n6.Export Employee list." +
                    "\n7.Schedule Tasks To Employee." +
                    "\nEnter your action : ", "Yellow");
                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:

                        // get user input
                        TasksDataManager.AddNewTask("CODE", "Add on feature", 20, new DateOnly(2023, 11, 12), "Coding");
                        Utility.DisplayListAsTable(TasksDataManager.TasksList);
                        break;
                    case 2:

                        // get user input
                        EmployeeDataManager.AddNewEmployee("2345", "Jack", 5, "Coding", true);
                        Utility.DisplayListAsTable(EmployeeDataManager.EmployeeList);
                        break;
                    case 3:
                        try
                        {
                            TasksDataManager.ImportTasksFromFile("myTaskFile");
                            Utility.DisplayListAsTable(TasksDataManager.TasksList);
                            Utility.DisplayListAsTable(EmployeeDataManager.EmployeeList);
                        }
                        catch
                        {
                            Utility.DisplayMessageInSpecificColor("Some Exception occurred.", "Red");
                        }

                        break;
                    case 4:
                        try
                        {
                            EmployeeDataManager.ImportEmployeesFromFile("myEmployeeFile");
                            Utility.DisplayListAsTable(TasksDataManager.TasksList);
                            Utility.DisplayListAsTable(EmployeeDataManager.EmployeeList);
                        }
                        catch
                        {
                            Utility.DisplayMessageInSpecificColor("Some Exception occurred.", "Red");
                        }

                        break;

                    case 5:
                        TasksDataManager.CreateTasksDetailsFile("NewTasksFile");
                        Utility.DisplayMessageInSpecificColor("File created successfully check bin >>>", "Green");
                        break;
                    case 6:
                        EmployeeDataManager.CreateEmployeeDetailsFile("NewEmployeesFile");
                        Utility.DisplayMessageInSpecificColor("File created successfully check bin >>>", "Green");
                        break;
                    case 7:
                        Scheduler.ScheduleManager();
                        Utility.DisplayListAsTable(TasksDataManager.TasksList);
                        Utility.DisplayListAsTable(EmployeeDataManager.EmployeeList);
                        break;
                    default:
                        Utility.DisplayMessageInSpecificColor("Invalid choice.", "Red");
                        break;
                }

                Utility.DisplayMessageInSpecificColor("Press any key to continue", "Green");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}