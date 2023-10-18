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
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (T choices in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{(int)(object)choices}. {choices}");
            }
            Console.ForegroundColor = ConsoleColor.White;
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
                Console.Write("Enter valid input and Adhere to the options:");
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
        /// Checks the deadline date with the provided hours to complete work from now.
        /// </summary>
        /// <param name="requiredHours">Required hours to complete a task.</param>
        /// <returns>Returns valid dead line date.</returns>
        public static DateTime GetValidDeadlineDate(double requiredHours)
        {
            DateTime deadlineDate = "deadline date for the task in (mm-dd-yyyy)format".GetValidInput<DateTime>();
            deadlineDate = deadlineDate.Add(new TimeSpan(23, 59, 59));
            while (deadlineDate < DateTime.Now.AddHours(requiredHours))
            {
                MessageDisplayer.DisplayWarningMessage("The required hours to perform task exceeds the deadline!!!");
                deadlineDate = "valid deadline date for the task in (mm-dd-yyyy)format".GetValidInput<DateTime>();
                deadlineDate = deadlineDate.Add(new TimeSpan(23, 59, 59));
            }
            return deadlineDate;
        }

        /// <summary>
        /// Allows Working Hours only if less than 12.
        /// </summary>
        /// <returns>Returns valid working hours.</returns>
        public static double GetValidWorkingHours()
        {
            double workHours = "working hours".GetValidInput<double>();
            while (workHours > 12)
            {
                MessageDisplayer.DisplayWarningMessage("Working Hours should be less than 12!!!");
                workHours = "working hours".GetValidInput<double>();
            }
            return workHours;
        }

        public static double GetValidRequiredHours()
        {
            double requiredHours = "hours required to complete the task".GetValidInput<double>();
            while (requiredHours < 0)
            {
                MessageDisplayer.DisplayWarningMessage("Required Hours should be greater than 0!!!");
                requiredHours = "hours required to complete the task".GetValidInput<double>();
            }
            return requiredHours;
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
        public static void ExportScheduledData()
        {
            using(StreamWriter streamWriter = new StreamWriter("ScheduledDetails.txt"))
            {
                ConsoleTable table = new ConsoleTable("Employee Name", "Working Hours", "Skills", " Skills Required", "Description", "DeadLine","Assigned For", "Required Hours");
                foreach ((Employee, Task, DateTime) tasksScheduled in TaskScheduler.ScheduledTasks)
                {
                    table.AddRow(
                        tasksScheduled.Item1.EmployeeName,
                        tasksScheduled.Item1.WorkingHours,
                        tasksScheduled.Item1.Skills,
                        tasksScheduled.Item2.Skills,
                        tasksScheduled.Item2.Description,
                        tasksScheduled.Item2.DeadlineDate.ToShortDateString(),
                        tasksScheduled.Item3.ToShortDateString(),
                        tasksScheduled.Item2.RequiredHours
                   );
                }
                streamWriter.WriteLine(table.ToString());
            }
        }
    }
}