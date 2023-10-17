using System.Text.RegularExpressions;

namespace EmployeeAndTaskScheduler
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            EmployeeList = 1,
            TaskList = 2,
            MapTheEmployeeAndTask = 3,
            Exit = 4,
        }
        private enum Operation
        {
            Add = 1,
            Display = 2,
            Exit = 3,
        }
        private enum MappingTheTask
        {
            DisplayAllAvailableEmployee = 1,
            DisplayAllAvailableTask = 2,
            MapTheTaskToTheEmployee = 3,
            Exit = 4,
        }
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">It is string array in the parameters of main method</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Welcome Task Assigner\n");
                Console.Write("1. Employee List, 2. Task List, 3. Map the Employee and Task, 4.Exit\n\nEnter the Choice : ");
                if (int.TryParse(Console.ReadLine(), out int userEnteredChoice))
                {
                    Options options = (Options)userEnteredChoice;
                    switch (options)
                    {
                        case Options.EmployeeList:
                            EmployeeOperation();
                            break;
                        case Options.TaskList:
                            TaskOperation();
                            break;
                        case Options.MapTheEmployeeAndTask:
                            MapTheEmployeeTask();
                            break;
                        case Options.Exit:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input - Please Enter the 1 to 4 numbers");
                }
                ClearScreen();
            }
        }
        /// <summary>
        /// User Interface for the Add and DisplayTheTask
        /// </summary>
        public static void TaskOperation()
        {
            Console.Write("\n1. Add the Task\n2. Display the Task \n\nEnter the Choice: ");
            if (int.TryParse(Console.ReadLine(), out int userInputChoice))
            {
                Operation employeeOperation = (Operation)userInputChoice;
                switch (employeeOperation)
                {
                    case Operation.Add:
                        AddTaskIntoTheFile();
                        break;
                    case Operation.Display:
                        string filePath = "Task.txt";
                        List<Task> tasksList = LoadTheTaskFromTheFile(filePath);
                        Console.WriteLine("Loaded Task List : \n");
                        foreach (Task task in tasksList)
                        {
                            Console.WriteLine(task);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// User Interface for the Add and DisplayTheTask
        /// </summary>
        public static void EmployeeOperation()
        {
            Console.Write("\n1. Add the Employee\n2. Display the Employee\n\nEnter the Choice : ");
            if (int.TryParse(Console.ReadLine(), out int userInputChoice))
            {
                Operation employeeOperation = (Operation)userInputChoice;
                switch (employeeOperation)
                {
                    case Operation.Add:
                        AddEmployeeIntoTheFile();
                        break;
                    case Operation.Display:
                        string filePath = "Employee.txt";
                        List<Employee> employees = LoadTheEmployeeFromTheFile(filePath);
                        Console.WriteLine("Loaded Employee List : \n");
                        foreach (Employee employee in employees)
                        {
                            Console.WriteLine(employee);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// User Interface for the assigning the task
        /// </summary>
        public static void MapTheEmployeeTask()
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("\n1 - Display all the Available Employee\n2 - Display all the Available Task\n3 - Map the Employee to the Task\n4 - Exit\n\nEnter The Option:");
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    MappingTheTask mappingTheTask = (MappingTheTask)userChoice;
                    switch (mappingTheTask)
                    {
                        case MappingTheTask.DisplayAllAvailableEmployee:
                            DisplayTheAvailableEmployee();
                            break;
                        case MappingTheTask.DisplayAllAvailableTask:
                            DisplayTheAvailableTask();
                            break;
                        case MappingTheTask.MapTheTaskToTheEmployee:
                            MapTheTaskToTheEmployee();
                            break;
                        case MappingTheTask.Exit:
                            flag = false;
                            break;
                    }
                }
                if (flag)
                {
                    ClearScreen();
                }
            }
        }

        /// <summary>
        /// Display which employees are available to work
        /// </summary>
        public static void DisplayTheAvailableEmployee()
        {
            List<Employee> employees = LoadTheEmployeeFromTheFile("employee.txt");
            var availableEmployee = employees.Where(employee => employee.availability == true).GetEnumerator();
            Console.WriteLine("\nList of the Available Employee: \n");
            while (availableEmployee.MoveNext())
            {
                Console.WriteLine($"Name : {availableEmployee.Current.employeeName}");
            }
        }
        /// <summary>
        /// Display available tasks
        /// </summary>
        public static void DisplayTheAvailableTask()
        {
            List<Task> employees = LoadTheTaskFromTheFile("task.txt");
            var availableEmployee = employees.OrderBy(task => task.DeadLine).GetEnumerator();
            Console.WriteLine("\nList of the Available Task: \n");
            while (availableEmployee.MoveNext())
            {
                Console.WriteLine($"Description: {availableEmployee.Current.description}");
            }
        }
        /// <summary>
        /// Find the required skill person and assign to the particular task
        /// </summary>
        public static void MapTheTaskToTheEmployee()
        {
            Dictionary<Task, Employee> AssignedTask = new Dictionary<Task, Employee>();
            int i = 1;
            List<Task> tasks = LoadTheTaskFromTheFile("task.txt");
            var availableTasks = tasks.OrderBy(task => task.DeadLine).ToList();
            foreach (var item in availableTasks)
            {
                Console.WriteLine($"{i}. Description : {item.description} DeadLine : {item.DeadLine} RequiredHours : {item.requiredHours}");
                i++;
            }
            Console.Write("\nEnter the task number to assign : ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= availableTasks.Count)
            {
                Task currentTask = availableTasks.ElementAt(taskNumber - 1);
                List<Employee> employees = LoadTheEmployeeFromTheFile("employee.txt");
                List<Employee> employeeWithRequiredSkills = new List<Employee>();
                var availableEmployee = employees.Where(employee => employee.availability == true).ToList();
                foreach (var item in availableEmployee)
                {
                    bool flag = true;
                    foreach (var item1 in currentTask.necessarySkills)
                    {
                        if (!item.skills.Contains(item1))
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        employeeWithRequiredSkills.Add(item);
                    }
                }
                Console.WriteLine("\nList of the Employee With Available Skills : \n");
                i = 1;
                foreach (var item in employeeWithRequiredSkills)
                {
                    Console.WriteLine($"{i}.Name : {item.employeeName}");
                    i++;
                }
                Console.Write("\nEnter the employee number : ");
                if (int.TryParse(Console.ReadLine(), out int employeeNumber) && employeeNumber > 0 && employeeNumber <= employeeWithRequiredSkills.Count)
                {
                    Employee currentEmployee = employeeWithRequiredSkills.ElementAt(employeeNumber - 1);
                    if (currentEmployee.workingHours >= currentTask.requiredHours)
                    {
                        AssignedTask.Add(currentTask, currentEmployee);
                    }
                    else
                    {
                        Console.WriteLine("Can't Assign the Task working hours less than the required hours");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Number - Please Enter the Valid Number");
                }
                Console.WriteLine("Task Assigned to Employee List : ");
                for(int j = 0; j < AssignedTask.Count; j++)
                {
                    Console.WriteLine($"{AssignedTask.ElementAt(j).Key.description} : {AssignedTask.ElementAt(j).Value.employeeName}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        /// <summary>
        /// Add the employee details in to the database using file
        /// </summary>
        public static void AddEmployeeIntoTheFile()
        {
            string name = ValidateName();
            string availability = string.Empty;
            string previousData = string.Empty;
            Console.Write("Enter the Working Hours : ");
            if (!int.TryParse(Console.ReadLine(), out int workingHours))
            {
                Console.WriteLine("Invalid Working Hours - Please Enter the valid number");
            }
            Console.Write("Enter the Skills by / separated : ");
            string skills = Console.ReadLine();
            Console.Write("Enter the availability true or false : ");
            string employeeAvailability = Console.ReadLine().ToLower();

            if (employeeAvailability.Equals("true") || employeeAvailability.Equals("false"))
            {
                availability = employeeAvailability;
            }
            using (StreamReader reader = new StreamReader("Employee.txt"))
            {
                previousData = reader.ReadToEnd();
            }
            using (StreamWriter writer = new StreamWriter("Employee.txt"))
            {
                writer.WriteLine($"{previousData}\r\n{name}, {workingHours}, [{skills}], {availability}");
            }
        }
        /// <summary>
        /// Add the Task details in the database by using file
        /// </summary>
        public static void AddTaskIntoTheFile()
        {
            string previousData = string.Empty;
            Console.Write("\nEnter the Description of the Task : ");
            string description = Console.ReadLine();
            Console.Write("Enter the Required Hours : ");
            if (!int.TryParse(Console.ReadLine(), out int requiredHours))
            {
                Console.WriteLine("Invalid Working Hours - Please Enter the valid number");
            }
            Console.Write("Enter DeadLine (format DD-MM-YYYY): ");
            string deadLine = Console.ReadLine();
            Console.Write("Enter the Skills by / separated : ");
            string skills = Console.ReadLine();
            using (StreamReader reader = new StreamReader("Task.txt"))
            {
                previousData = reader.ReadToEnd();
            }
            using (StreamWriter writer = new StreamWriter("Task.txt"))
            {
                writer.Write($"{previousData}\r\n{description}, {requiredHours}, {deadLine}, [{skills}]");
            }
        }
        /// <summary>
        /// Load the File Data from the file into the program
        /// </summary>
        /// <param name="file">Path for the file</param>
        /// <returns>List of the employee data</returns>
        public static List<Employee> LoadTheEmployeeFromTheFile(string file)
        {
            List<Employee> employeeList = new List<Employee>();
            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string[] dataOfTheEmployees = sr.ReadToEnd().Split("\n");
                    for (int i = 0; i < dataOfTheEmployees.Length; i++)
                    {
                        if (!dataOfTheEmployees[i].Equals(string.Empty))
                        {
                            string[] dataOfTheEmployee = dataOfTheEmployees[i].Split(",");
                            if (!dataOfTheEmployees[i].Equals("\r") && !dataOfTheEmployees[i].Equals(string.Empty))
                            {
                                Employee employeeData = new Employee(dataOfTheEmployee[0], dataOfTheEmployee[1], dataOfTheEmployee[2], dataOfTheEmployee[3]);
                                employeeList.Add(employeeData);
                            }
                        }
                    }
                }
                return employeeList;
            }
            else
            {
                Console.WriteLine("File Path Doesn't Exits");
                return null;
            }
        }
        /// <summary>
        /// Load the Task Data from the file into the program
        /// </summary>
        /// <param name="file">Path for the file</param>
        /// <returns>List of the Task data</returns>
        public static List<Task> LoadTheTaskFromTheFile(string file)
        {
            List<Task> taskList = new List<Task>();
            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string[] dataOfTheTasks = sr.ReadToEnd().Split("\n");
                    for (int i = 0; i < dataOfTheTasks.Length; i++)
                    {
                        string[] dataOfTheTask = dataOfTheTasks[i].Split(",");
                        if (!dataOfTheTasks[i].Equals("\r") && !dataOfTheTasks[i].Equals(string.Empty))
                        {
                            Task TaskData = new Task(dataOfTheTask[0], dataOfTheTask[1], dataOfTheTask[2], dataOfTheTask[3]);
                            taskList.Add(TaskData);
                        }
                    }
                }
                return taskList;
            }
            else
            {
                Console.WriteLine("File Path Doesn't Exits");
                return null;
            }
        }

        /// <summary>
        /// To Clear the Screen
        /// </summary>
        public static void ClearScreen()
        {
            Console.WriteLine("\nPress any enter to clear and escape to continue : ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if (consoleKey.Equals(ConsoleKey.Enter))
            {
                Console.Clear();
            }
            else if (consoleKey.Equals(ConsoleKey.Escape))
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Key entered");
                Console.WriteLine("Press the Escape Key to exit");
                if (Console.ReadKey().Key.Equals(ConsoleKey.Escape))
                {
                    return;
                }

                ClearScreen();
            }
        }
        /// <summary>
        /// In order to validate the name
        /// </summary>
        /// <returns>returns the valid name</returns>
        public static string ValidateName()
        {
            Console.Write("\nEnter the Name : ");
            string name = Console.ReadLine();
            Regex regex = new Regex("^[a-zA-Z\\s]+$");
            if (regex.IsMatch(name))
            {
                return name;
            }
            else
            {
                Console.WriteLine("Invalid Name");
            }
            return string.Empty;
        }
    }
}