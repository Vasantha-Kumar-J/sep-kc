namespace EmployeeManager
{
    using ConsoleTables;

    /// <summary>
    /// Implements methods for employee manager menu.
    /// </summary>
    internal static class UserMenu
    {
        /// <summary>
        /// Prints the menu.
        /// </summary>
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the operation you want to perform: ");
            Console.WriteLine("1. Add Employee\n" +
                "2. Remove Employee\n" +
                "3. Add Task\n" +
                "4. Remove Task\n" +
                "5. Schedule Tasks\n" +
                "6. Print Employees\n" +
                "7. Print Tasks\n" +
                "8. Import Employees\n" +
                "9. Import tasks\n" +
                "0. Exit\n");
            Console.Write("Enter your choice as number or text: ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Clears the screen.
        /// </summary>
        public static void ClearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Gets the user choice.
        /// </summary>
        /// <returns>User choice.</returns>
        public static UserChoice GetUserChoice()
        {
            while (true) {
                string userInput = Console.ReadLine();
                if (userInput == "0" || userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.Exit;
                }
                else if (userInput == "1" || userInput.Equals("add employee", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.AddEmployee;
                }
                else if (userInput == "2" || userInput.Equals("remove employee", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.RemoveEmployee;
                }
                else if (userInput == "3" || userInput.Equals("add task", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.AddTask;
                }
                else if (userInput == "4" || userInput.Equals("remove task", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.RemoveTask;
                }
                else if (userInput == "5" || userInput.Equals("schedule tasks", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.ScheduleTasks;
                }
                else if (userInput == "6" || userInput.Equals("print employees", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.PrintEmployees;
                }
                else if (userInput == "7" || userInput.Equals("print tasks", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.PrintTasks;
                }
                else if (userInput == "8" || userInput.Equals("import employees", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.ImportEmployees;
                }
                else if (userInput == "9" || userInput.Equals("import tasks", StringComparison.OrdinalIgnoreCase))
                {
                    return UserChoice.ImportTasks;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The option you've entered is not present in our list of operations...");
                    Console.Write("Please enter one of the options given above: ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Adds an employee.
        /// </summary>
        /// <param name="employeesObj">Employees object.</param>
        public static void AddEmployee(EmployeeOperations employeesObj)
        {
            Console.Clear();
            Console.WriteLine("Adding an employee...");
            int id;
            Console.Write("Enter the employee id: ");
            while (true) 
            {
                if (!int.TryParse(Console.ReadLine(), out id) )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter only numerics: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            string name;
            while (true)
            {
                Console.Write("Enter the employee name: ");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name cannot be empty...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            int workingHours;
            while (true)
            {
                Console.Write("Enter the working hours: ");
                if (!int.TryParse(Console.ReadLine(), out workingHours))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter only numerics...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (workingHours <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Working hours cannot be 0 or negative...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            List<string> skills = new List<string>();
            while (true)
            {
                Console.Write("Enter the skills of the employee one by one and press n to stop: ");
                string skill = Console.ReadLine();
                if (skill.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (string.IsNullOrEmpty(skill))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Skill cannot be empty...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                skills.Add(skill);
            }

            Employee employee = new Employee(id, name, workingHours, skills, true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("An employee is added with the following details:");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Working Hours: {workingHours}");
            Console.Write("Skills: ");
            foreach (string skill in skills)
            {
                Console.Write($"{skill} ");
            }
            Console.WriteLine();
            Console.WriteLine("Is Available: true");
            Console.ForegroundColor = ConsoleColor.White;

            employeesObj.AddEmployee(employee);
            ClearScreen();
        }

        /// <summary>
        /// Removes an employee from the collection, if present.
        /// </summary>
        /// <param name="employeesObj">Employees object.</param>
        /// <returns><see langword="true"/>, if the employee is successfully removed; otherwise, <see langword="false"/>.</returns>
        public static void RemoveEmployee(EmployeeOperations employeesObj)
        {
            Console.Clear();
            Console.WriteLine("Removing an employee...");
            PrintEmployees(employeesObj);
            Console.WriteLine("Enter the employee id you want to remove or press n to go back to main menu");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (!int.TryParse(input, out int id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter only numerics: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (!employeesObj.TryRemoveEmployee(id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("The ID you've entered is not present in the employees collection!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                break;
            }

            ClearScreen();
        }

        /// <summary>
        /// Prints the employees in the collection.
        /// </summary>
        /// <param name="employeesObj"></param>
        public static void PrintEmployees(EmployeeOperations employeesObj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            IEnumerable<Employee> employees = employeesObj.GetEmployees();
            ConsoleTable table = new ConsoleTable("Id", "Name");
            foreach (Employee employee in employees)
            {
                table.AddRow(employee.Id, employee.Name);
            }

            table.Write();
            Console.ForegroundColor = ConsoleColor.White;
        }

        // TODO: remaining UI flow
    }
}
