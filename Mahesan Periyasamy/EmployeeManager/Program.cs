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
                        RemoveEmployee(employeesObj);
                        break;

                    case UserChoice.PrintEmployees:
                        PrintEmployees(employeesObj);
                        break;

                    case UserChoice.Exit:
                        Console.WriteLine("Thank you for using our application!");
                        return;
                }
            }
        }
    }
}