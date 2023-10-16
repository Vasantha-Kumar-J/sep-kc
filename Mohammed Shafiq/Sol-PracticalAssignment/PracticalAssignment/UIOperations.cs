using System.Dynamic;

namespace PracticalAssignment
{
    internal partial class Program
    {
        public class UIOperations
        {
            public static void Menu()
            {
                Console.WriteLine("\t\tWelcome!!\n");
                int choice = 1;
                while (choice != 0)
                {
                    Console.WriteLine("\n\nThere are some Operations..");
                    Console.WriteLine("1.Add Employee\n2.Add List of Task\n3.Allocate a task to Employee\n4.Display All Employees\n5.Diaplay all Tasks\n6.Allocate all Tasks\n7.serilize All\n0.Exit");
                    choice = Utilities.GetValidInput<int>(@"^[0-7]$", "Enter you choice : ", "Invalid choice!!");
                    switch (choice)
                    {
                        case 1:
                            {
                                string path = Utilities.GetValidFilePath();
                                if (path == string.Empty)
                                {
                                    break;
                                }

                                FileHandler handler = new FileHandler();
                                try
                                {
                                    Operations.WorkingEmployees.Add(handler.GetEmployeeDetails(path));
                                }
                                catch (Exception ex)
                                {
                                    Operations.LogErrors("./Message/error.txt", ex.Message);
                                }

                                break;
                            }
                        case 2:
                            {
                                string path = Utilities.GetValidFilePath();
                                if (path == string.Empty)
                                {
                                    break;
                                }

                                FileHandler handler = new FileHandler();
                                try
                                {
                                    Operations.AvailableWorks.AddRange(handler.GetWorks(path));
                                }
                                catch (Exception ex)
                                {
                                    Operations.LogErrors("./Message/error.txt", ex.Message);
                                }
                                
                                break;
                            }
                        case 3:
                            {
                                Work? work = GetWork();
                                if (work == null)
                                {
                                    Console.WriteLine("There is no such Task exist!!");
                                    break;
                                }

                                Operations operations = new Operations();
                                try
                                {
                                    operations.AssignEmployee(work, Operations.WorkingEmployees);
                                }
                                catch (Exception ex)
                                {
                                    Operations.LogErrors("./Message/error.txt", ex.Message);
                                }

                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine("\n\n\t\tThank you !");
                                break;
                            }
                        case 4:
                            {
                                PrintEmployeeDetails(Operations.WorkingEmployees);
                                break;
                            }
                        case 5:
                            {
                                PrintTaskDetails(Operations.AvailableWorks);
                                break;
                            }
                        case 6:
                            {
                                Operations operations = new Operations();
                                operations.AssignEmployeeToAllTasks(Operations.AvailableWorks, Operations.WorkingEmployees);
                                break;
                            }
                        case 7:
                            {
                                Operations operations = new();
                                operations.SerilizeObject<Employee>(Operations.WorkingEmployees, "./Objects/Employees.txt");
                                operations.SerilizeObject<Work>(Operations.AvailableWorks, "./Objects/Tasks.txt");
                                break;
                            }
                    }
                }
            }

            private static void PrintEmployeeDetails(List<Employee> employees)
            {
                Console.WriteLine("\n\nAvailable Employees are : ");
                foreach (var employee in employees)
                {
                    Console.Write($"ID : {employee.ID,-5} Name : {employee.Name,-15}Status : {employee.IsAvaLiable,-10}\nTask : \n");
                    foreach (var work in employee.Tasks)
                    {
                        Console.Write($"\tTask ID : {work.Key.ID} -> Working Hours : {work.Value}\n");
                    }
                    Console.Write("\nSkills : ");
                    foreach (var skill in employee.Skills)
                    {
                        Console.Write($"{skill},  ");
                    }
                    Console.WriteLine("\n-----------------------------------------------------------------------------");
                }
            }

            public static void PrintTaskDetails(List<Work> tasks)
            {
                Console.WriteLine("\n\nThe Available tasks are ");
                foreach (var work in tasks)
                {
                    Console.Write($"ID : {work.ID,-5}Description : {work.Description,-30}Required Hours : {work.RequiredHours,-5}\nDeadLine : {work.DeadLine,-15}Is Scheduled : {work.IsScheduled, -8}Possible to complete in Deadline : {work.IsPossibleToComplete}\nEmployees : \n");
                    foreach (var employee in work.Employees)
                    {
                        Console.Write($"\tEmployee ID : {employee.Key.ID} - WorkingHours : {employee.Value}\n");
                    }
                    Console.Write("\nSkills : ");
                    foreach (var skill in work.RequiredSkills)
                    {
                        Console.Write($"{skill}, ");
                    }
                    Console.WriteLine("\n-----------------------------------------------------------------------------\n\n");

                }

            }

            private static Work? GetWork()
            {
                PrintTaskDetails(Operations.AvailableWorks);
                int id = Utilities.GetValidInput<int>(@"^[0-9]{1,2}$", "Enter Task ID : ", "Enter valid Task ID!");
                foreach (var work in Operations.AvailableWorks)
                {
                    if (id == work.ID)
                    {
                        return work;
                    }
                }

                return null;
            }
        }
    }
}