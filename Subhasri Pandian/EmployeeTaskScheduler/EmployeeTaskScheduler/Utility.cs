using ConsoleTables;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace EmployeeTaskScheduler
{
    public static class Utility
    {
        /// <summary>
        /// DisplayChoicesInEnum - Display options in the enum
        /// </summary>
        /// <typeparam name="T">Enum type parameter</typeparam>
        public static void DisplayChoicesInEnum<T>()
        {
            foreach (T choices in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{(int)(object)choices}. {choices}");
            }
        }

        /// <summary>
        /// GetValidUserChoice() function gets unparsedinput and parses it into valid int.
        /// </summary>
        /// <param name="numberOfChoices">number of choices to validate based on enum length. </param>
        /// <returns>Returns parsed int value of user choice.</returns>
        public static int GetValidUserChoice(this int numberOfChoices)
        {
            int userChoice;
            string? unparsedUserChoice = Console.ReadLine();
            while (!int.TryParse(unparsedUserChoice, out userChoice) || !(userChoice > 0 && userChoice <= numberOfChoices))
            {
                Console.WriteLine("Enter valid input and Adhere to the options:");
                unparsedUserChoice = Console.ReadLine();
            }

            return userChoice;
        }

        /// <summary>
        /// GetvalidInput() - functions gets valid input from the user.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="printingData">Data to be displayed in WriteLine for the use.</param>
        /// <returns>Returns valid input of generic type.</returns>
        public static T GetValidInput<T>(this string printingData)
        {
            Console.Write($"Enter {printingData}: ");
            string? unparsedInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(unparsedInput) || !TypeDescriptor.GetConverter(typeof(T)).IsValid(unparsedInput))
            {
                Console.Write($"\nEnter Valid {printingData}: ");
                unparsedInput = Console.ReadLine();
            }

            T validInput = (T)Convert.ChangeType(unparsedInput, typeof(T));
            return validInput;
        }

        /// <summary>
        /// GetValidName - gets valid name checking the regex.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="printingMessage">Message to be printed.</param>
        /// <param name="regexForValidation">Regex for Validation.</param>
        /// <returns>Valid string name that matches regex.</returns>
        public static T GetValidName<T>(this string printingMessage, string regexForValidation)
        {
            string stringName = printingMessage.GetValidInput<string>();
            while (!Regex.IsMatch(stringName, regexForValidation))
            {
                Console.WriteLine($"Enter valid {printingMessage}: ");
                stringName = printingMessage.GetValidInput<string>();
            }

            T validInput = (T)Convert.ChangeType(stringName, typeof(T));
            return validInput;
        }

        public static void DisplayCheckForEmployee()
        {
            EmployeeServices accessServices = new EmployeeServices();
            if (!EmployeeServices.IsEmployeeAvailable())
            {
                Console.WriteLine("\nEMPLOYEES\n");
                accessServices.DisplayEmployees(Employee.Employees);
            }
            else
            {
                Console.WriteLine("No employees availbale\n");
            }
        }

        public static void DisplayCheckForTasks()
        {
            TaskServices accessTaskService = new TaskServices();
            if (!TaskServices.IsTasksAvailable())
            {
                Console.WriteLine("\nTASKS");
                accessTaskService.DisplayTasks(Task.Tasks);
            }
            else
            {
                Console.WriteLine("No tasks availbale\n");
            }
        }

        public static void DisplayCheckForNotAvailableEmployees()
        {
            EmployeeServices accessServices = new EmployeeServices();
            if (TaskScheduler.NotAvailableEmployees.Count != 0)
            {
                Console.WriteLine("\nUNAVAILABLE EMPLOYEES\n");
                accessServices.DisplayEmployees(TaskScheduler.NotAvailableEmployees);
            }
            else
            {
                Console.WriteLine("All the employees are available\n");
            }
        }

        public static void DisplayCheckForScheduledTasks()
        {
            TaskScheduler scheduler = new TaskScheduler();
            if (TaskScheduler.ScheduledTasks.Count != 0)
            {
                Console.WriteLine("\nSCHEDULED TASKS\n");
                scheduler.DisplayScheduledTasks();
            }
            else
            {
                Console.WriteLine("No task has been scheduled! Try scheduling tasks.\n");
            }
        }

        public static void DisplayCheckForUnscheduledTasks()
        {
            TaskServices accessTaskService = new TaskServices();
            foreach (Task task in Task.Tasks)
            {
                if (task.Assigned == false)
                {
                    TaskScheduler.TasksUnscheduled.Add(task);
                }
            }
            if (TaskScheduler.TasksUnscheduled.Count != 0)
            {
                Console.WriteLine("\nTASKS UNSCHEDULED");
                accessTaskService.DisplayTasks(TaskScheduler.TasksUnscheduled);
            }
            else
            {
                Console.WriteLine("No tasks unscheduled\n");
            }
        }

        public static void DisplayCheckForEmployeesWithNoTasksScheduled()
        {
            EmployeeServices accessServices = new EmployeeServices();
            if (TaskScheduler.EmployeesWithNoTasksScheduled.Count != 0)
            {
                Console.WriteLine("\nEMPLOYEES WITH NO TASKS SCHEDULED\n");
                accessServices.DisplayEmployees(TaskScheduler.EmployeesWithNoTasksScheduled);
            }
            else
            {
                Console.WriteLine("All the employees have tasks scheduled\n");
            }
        }

        /// <summary>
        /// Logs in the text file.
        /// </summary>
        /// <param name="textToBeLogged">The text to be logged.</param>
        public static void LogInFile(string textToBeLogged)
        {
            using(StreamWriter streamWriter = new StreamWriter("log.txt", true))
            {
                streamWriter.WriteLine($"{textToBeLogged} {DateTime.Now} \n");
            }
        }

        /// <summary>
        /// Exports the scheduled data to text file.
        /// </summary>
        public static void exportData()
        {
            using(StreamWriter streamWriter = new StreamWriter("ScheduledDetails.txt"))
            {
                ConsoleTable table = new ConsoleTable("Employee Name", "Working Hours", "Skills", " Skills Required", "Description", "DeadLine", "Required Hours");
                foreach ((Employee, Task) tasksScheduled in TaskScheduler.ScheduledTasks)
                {
                    table.AddRow(
                        tasksScheduled.Item1.EmployeeName,
                        tasksScheduled.Item1.WorkingHours,
                        tasksScheduled.Item1.Skills,
                        tasksScheduled.Item2.Skills,
                        tasksScheduled.Item2.Description,
                        tasksScheduled.Item2.DeadlineDate,
                        tasksScheduled.Item2.RequiredHours
                   );
                }
                streamWriter.WriteLine(table.ToString());
            }
        }
    }
}