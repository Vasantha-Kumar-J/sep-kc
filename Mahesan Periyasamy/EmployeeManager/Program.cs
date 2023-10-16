namespace EmployeeManager
{
    using static UserMenu;

    /// <summary>
    /// Driver class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Driver method.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Welcome to the Employee Management Application!");
            EmployeeOperations employeesObj = new EmployeeOperations();
            TaskOperations tasksObj = new TaskOperations();
            Scheduler scheduler = new Scheduler();
            while (true)
            {
                PrintMenu();
                UserChoice choice = GetUserChoice();

                switch (choice)
                {
                    case UserChoice.AddEmployee:
                        AddEmployee(employeesObj);
                        break;

                    case UserChoice.RemoveEmployee:
                        TryRemoveEmployee(employeesObj);
                        break;

                    case UserChoice.AddTask:
                        AddTask(tasksObj);
                        break;

                    case UserChoice.RemoveTask:
                        TryRemoveTask(tasksObj);
                        break;

                    case UserChoice.ScheduleTasks:
                        ScheduleTasks(employeesObj, tasksObj, scheduler);
                        break;

                    case UserChoice.PrintEmployees:
                        Console.Clear();
                        PrintEmployees(employeesObj);
                        ClearScreen();
                        break;

                    case UserChoice.PrintTasks:
                        Console.Clear();
                        PrintTasks(tasksObj);
                        ClearScreen();
                        break;

                    case UserChoice.ImportEmployees:
                        ImportEmployees(employeesObj);
                        break;

                    case UserChoice.ImportTasks:
                        ImportTasks(tasksObj);
                        break;

                    case UserChoice.Exit:
                        Console.WriteLine("Thank you for using our application!");
                        return;
                }
            }
        }
    }
}