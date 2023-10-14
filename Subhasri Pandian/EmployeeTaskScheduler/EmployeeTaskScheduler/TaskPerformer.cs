using System.IO;

namespace EmployeeTaskScheduler
{
    public class TaskPerformer
    {
        /// <summary>
        /// PerformAllTasks - performs tasks according to user input.
        /// </summary>
        public static void PerformAllTasks()
        {
            bool exit = false;
            do
            {
                Utility.DisplayChoicesInEnum<TasksToPerform>();
                Console.Write("Enter specific task to perform: ");
                int userChoice = Enum.GetNames(typeof(TasksToPerform)).Length.GetValidUserChoice();
                switch (userChoice)
                {
                    case (int)TasksToPerform.AddEmployee:
                        PerformAddEmployee();
                        break;
                    case (int)TasksToPerform.AddTasks:
                        PerformAddTasks();
                        break;
                    case (int)TasksToPerform.ScheduleTasks:
                        PerformSchedulingTasks();
                        break;
                    case (int)TasksToPerform.ImportData:
                        PerformImportData();
                        break;
                    case (int)TasksToPerform.ViewLog:
                        PerformViewLog();
                        break;
                    case (int)TasksToPerform.ViewReport:
                        PerformViewReport();
                        break;
                    case (int)TasksToPerform.ClearConsole:
                        Console.Clear();
                        break;
                    case (int)TasksToPerform.Exit:
                        exit = true;
                        Console.WriteLine("\nExiting Console!!");
                        break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Gets employee details and adds it to the list.
        /// </summary>
        public static void PerformAddEmployee()
        {
            EmployeeServices accessServices = new EmployeeServices();
            Employee employee = accessServices.GetEmployeeDetails();
            Employee.Employees.Add(employee);
            Console.WriteLine("EMPLOYEE DETAILS ADDED\n");
            Utility.LogInFile($"Employee List Added\n{Employee.Employees}");
        }

        /// <summary>
        /// Gets task details and adds it to the list.
        /// </summary>
        public static void PerformAddTasks()
        {
            TaskServices accessServices = new TaskServices();
            Task task = accessServices.GetTaskDetails();
            Task.Tasks.Add(task);
            Console.WriteLine("TASK DETAILS ADDED\n");
            Utility.LogInFile($"Task Details Added\n{Task.Tasks}");
        }

        /// <summary>
        /// Gets data from the file and adds it to the list.
        /// </summary>
        public static void PerformImportData()
        {
            EmployeeServices accessServices = new EmployeeServices();
            accessServices.GetFileEmployeeDetails();
            TaskServices accessTaskService = new TaskServices();
            accessTaskService.GetFileTaskDetails();
            Console.WriteLine("IMPORTED DATA\n");
            Utility.LogInFile($"Employee and task imported from file\n{Employee.Employees} \n{Task.Tasks}");
        }

        /// <summary>
        /// Performs tasks to be done to schedule.
        /// </summary>
        public static void PerformSchedulingTasks()
        {
            if (EmployeeServices.IsEmployeeAvailable())
            {
                Console.WriteLine("\nNo employees are available!! Try adding new employees or import data!\n");
                return;
            }
            if (TaskServices.IsTasksAvailable())
            {
                Console.WriteLine("\nNo tasks are available!! Try adding new tasks or import data!\n");
                return;
            }
            Task.Tasks.Sort(TaskServices.SortByDeadLine);
            Employee.Employees.Sort(EmployeeServices.SortByWorkingHours);
            Console.WriteLine("\nPRIORITY UPDATED");
            TaskScheduler scheduler = new TaskScheduler();
            scheduler.ScheduleTasks();
            Console.WriteLine("\nTASKS SCHEDULED\n");
            Utility.LogInFile($"Tasks Scheduled\n {TaskScheduler.ScheduledTasks}");
            Utility.exportData();
        }

        /// <summary>
        /// Displays log to the user.
        /// </summary>
        public static void PerformViewLog()
        {
            Console.WriteLine("LOG FILE\n");
            using(StreamReader streamReader = new StreamReader("log.txt"))
            {
                if (streamReader.BaseStream.Length == 0)
                {
                    Console.WriteLine("No Logs to read\n");
                    return;
                }
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }

        /// <summary>
        /// Performs All Viewing tasks.
        /// </summary>
        public static void PerformViewReport()
        {
            Utility.DisplayCheckForEmployee();
            Utility.DisplayCheckForTasks();
            Utility.DisplayCheckForNotAvailableEmployees();
            Utility.DisplayCheckForScheduledTasks();
            Utility.DisplayCheckForUnscheduledTasks();
            Utility.DisplayCheckForEmployeesWithNoTasksScheduled();
            Utility.LogInFile("Viewed Report");
        }
    }
}