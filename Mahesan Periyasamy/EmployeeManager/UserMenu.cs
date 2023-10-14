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
            Console.WriteLine(
                "1. Add Employee\n" +
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
            while (true)
            {
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
            Console.Write("Enter the employee ID: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
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
        public static void TryRemoveEmployee(EmployeeOperations employeesObj)
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
        /// Adds a task to the collection.
        /// </summary>
        /// <param name="tasksObj"></param>
        public static void AddTask(TaskOperations tasksObj)
        {
            Console.Clear();
            Console.WriteLine("Adding a task...");
            Console.WriteLine("Enter the task ID: ");
            int id;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter only numerics: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;

            }

            string description;
            while (true)
            {
                Console.WriteLine("Enter the description of the task: ");
                description = Console.ReadLine();
                if (string.IsNullOrEmpty(description))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task description cannot be empty...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            int requiredHours;
            while (true)
            {
                Console.Write("Enter the required hours for the task: ");
                if (!int.TryParse(Console.ReadLine(), out requiredHours))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter only numerics...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (requiredHours <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Required hours cannot be negative or zero...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            DateTime deadline;
            while (true)
            {
                Console.WriteLine("Enter the deadline of the task (Format: yyyy/mm/dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out deadline))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter the deadline in correct format: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (deadline < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("The date entered is earlier than today...");
                    Console.Write("Please enter a valid deadline: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            string skillNeeded;
            while (true)
            {
                Console.Write("Enter the skill needed to complete task: ");
                skillNeeded = Console.ReadLine();
                if (string.IsNullOrEmpty(skillNeeded))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Skill needed cannot be empty...");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The task with following details have been added successfully: ");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Required Hours: {requiredHours}");
            Console.WriteLine($"Deadline: {deadline.Date}");
            Console.Write($"Skill needed: {skillNeeded}");
            Console.ForegroundColor = ConsoleColor.White;

            tasksObj.AddTask(new Task(id, description, requiredHours, deadline, skillNeeded));
        }

        /// <summary>
        /// Removes task from the collection, if present.
        /// </summary>
        /// <param name="tasksObj">Task object.</param>
        public static void TryRemoveTask(TaskOperations tasksObj)
        {
            Console.Clear();
            Console.WriteLine("Removing a task...");
            PrintTasks(tasksObj);
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

                if (!tasksObj.TryRemoveTask(id))
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
        /// Schedules tasks.
        /// </summary>
        /// <param name="employeesObj"></param>
        /// <param name="tasksObj"></param>
        /// <param name="scheduler"></param>
        public static void ScheduleTasks(EmployeeOperations employeesObj, TaskOperations tasksObj, Scheduler scheduler)
        {
            List<Employee> employees = employeesObj.GetEmployees().ToList();
            List<Task> tasks = tasksObj.GetTasks().ToList();
            var tasksAssigned = scheduler.Schedule(employees, tasks);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Tasks Assigned: ");
            ConsoleTable tasksAssignedTable = new ConsoleTable("Employee ID", "Employee", "Task ID", "Task", "Hours Assigned");
            foreach (var task in tasksAssigned)
            {
                tasksAssignedTable.AddRow(task.Key.Key.Id, task.Key.Key.Name, task.Key.Value.Id, task.Key.Value.Description, task.Value);
            }

            tasksAssignedTable.Write();

            var tasksNotAssigned = scheduler.NotAssignedTasks(tasks);
            ConsoleTable tasksNotAssignedTable = new ConsoleTable("Task ID", "Task Description");
            foreach (var task in tasksNotAssigned) 
            {
                tasksNotAssignedTable.AddRow(task.Id, task.Description);
            }

            tasksNotAssignedTable.Write();
        }

        /// <summary>
        /// Imports the employees from the file.
        /// </summary>
        public static void ImportEmployees(EmployeeOperations employeesObj)
        {
            Console.Clear();
            Console.WriteLine("Importing employees from a csv file...");
            Console.WriteLine("Enter the file path to import employees");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING!! File must be in csv format\n" +
                "Format -> (ID, Name, Working Hours, Skills (seperated by comma values))\n");
            Console.ForegroundColor = ConsoleColor.White;
            string path;
            while (true)
            {
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The path you've entered is invalid.");
                    Console.Write("Please enter a valid path: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            try
            {
                List<Employee> employees = FileOperations.ImportEmployees(path);
                foreach (Employee employee in employees)
                {
                    employees.Add(employee);
                }
                Console.WriteLine("Employees has been added from the file...");
                ClearScreen();
            }
            catch (InvalidTaskFileException exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was some problem with opening the file.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Imports the tasks from the file.
        /// </summary>
        public static void ImportTasks(TaskOperations tasksObj)
        {
            Console.Clear();
            Console.WriteLine("Importing tasks from a csv file...");
            Console.WriteLine("Enter the file path to import tasks");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING!! File must be in csv format\n" +
                "Format -> (ID, Description, Required Hours, Deadline (yyyy/mm/dd), Skill Needed)\n");
            Console.ForegroundColor = ConsoleColor.White;
            string path;
            while (true)
            {
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The path you've entered is invalid.");
                    Console.Write("Please enter a valid path: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            try
            {
                List<Task> tasks = FileOperations.ImportTasks(path);
                foreach (Task task in tasks)
                {
                    tasksObj.AddTask(task);
                }
                Console.WriteLine("Tasks has been added from the file...");
                ClearScreen();
            }
            catch (InvalidEmployeeFileException exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was some problem with opening the file.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Prints the employees in the collection.
        /// </summary>
        /// <param name="employeesObj">Employees object.</param>
        public static void PrintEmployees(EmployeeOperations employeesObj)
        {
            Console.WriteLine("Printing the employees...");
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

        /// <summary>
        /// Prints the tasks in the collection.
        /// </summary>
        /// <param name="tasksObj">Tasks object.</param>
        public static void PrintTasks(TaskOperations tasksObj)
        {
            Console.WriteLine("Printing the tasks...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            IEnumerable<Task> tasks = tasksObj.GetTasks();
            ConsoleTable table = new ConsoleTable("Id", "Description");
            foreach (Task task in tasks)
            {
                table.AddRow(task.Id, task.Description);
            }

            table.Write();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
