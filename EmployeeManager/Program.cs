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
            EmployeeOperations employees = new EmployeeOperations();
            TaskOperations tasks = new TaskOperations();
            while (true)
            {
                PrintMenu();
                UserChoice choice = GetUserChoice();

                switch (choice)
                {
                    case UserChoice.AddEmployee:
                        AddEmployee(employees);
                        break;

                    case UserChoice.Exit:
                        Console.WriteLine("Thank you for using our application!");
                        return;
                }
            }
        }
    }
}