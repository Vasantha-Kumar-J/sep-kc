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
                int choice = 0;
                while (choice != 6)
                {
                    Console.WriteLine("There are some Operations..");
                    Console.WriteLine("1.Add Employee\n2.Add List of Task\n3.Allocate a task to Employee\n4.Display All Employees\n5.Diaplay all Tasks\n6.Exit");
                    choice = Utilities.GetValidInput<int>(@"^[1-6]$", "Enter you choice : ", "Invalid choice!!");
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
                                Operations.WorkingEmployees.Add(handler.GetEmployeeDetails(path));
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
                                Operations.AvailableWorks.AddRange(handler.GetWorks(path));
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
                                operations.AssignEmployee(work, Operations.WorkingEmployees);
                                break;
                            }
                        case 6:
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
                    }
                }
            }

            private static void PrintEmployeeDetails(List<Employee> employees)
            {
                Console.WriteLine("\n\nAvailable Employees are : ");
                foreach (var employee in employees)
                {
                    Console.Write($"{employee.ID,-5}{employee.Name,-15}{employee.IsAvaLiable,-10}\nTask : ");
                    foreach (var work in employee.Tasks)
                    {
                        Console.Write($"{work.Key.ID} - {work.Value}, ");
                    }
                    Console.Write("\nSkills : ");
                    foreach (var skill in employee.Skills)
                    {
                        Console.Write($"{skill}, ");
                    }
                    Console.WriteLine("\n-----------------------------------------------------------------------------");
                }
            }

            public static void PrintTaskDetails(List<Work> tasks)
            {
                Console.WriteLine("\n\nThe Available tasks are ");
                foreach (var work in tasks)
                {
                    Console.Write($"{work.ID,-5}{work.Description,-40}{work.RequiredHours,-5}{work.DeadLine,-15}\n Task : ");
                    foreach (var employee in work.Employees)
                    {
                        Console.Write($"{employee.Key.ID} - {employee.Value}, ");
                    }
                    Console.Write("\nSkills : ");
                    foreach (var skill in work.RequiredSkills)
                    {
                        Console.Write($"{skill}, ");
                    }
                    Console.WriteLine("\n-----------------------------------------------------------------------------");

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