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
            PerformImportData();
            do
            {
                MessageDisplayer.DisplayTitle("\nEMPLOYEE TASK SCHEDULER");
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
                        MessageDisplayer.DisplayMessage("\nExiting Console!!");
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
            MessageDisplayer.DisplayMessage("Employee Details Added...\n");
            Utility.LogInFile($"Employee List Added\n");
        }

        /// <summary>
        /// Gets task details and adds it to the list.
        /// </summary>
        public static void PerformAddTasks()
        {
            TaskServices accessServices = new TaskServices();
            Task task = accessServices.GetTaskDetails();
            Task.Tasks.Add(task);
            MessageDisplayer.DisplayMessage("Task Details Added...\n");
            Utility.LogInFile($"Task Details Added\n");
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
            Utility.LogInFile($"Employee and task imported from file\n");
        }

        /// <summary>
        /// Performs tasks to be done to schedule.
        /// </summary>
        public static void PerformSchedulingTasks()
        {
            if (EmployeeServices.IsEmployeeAvailable())
            {
                MessageDisplayer.DisplayWarningMessage("\nNo employees are available!! Try adding new employees or import data!\n");
                return;
            }
            if (TaskServices.IsTasksAvailable())
            {
                MessageDisplayer.DisplayWarningMessage("\nNo tasks are available!! Try adding new tasks or import data!\n");
                return;
            }
            Task.Tasks.Sort(TaskServices.SortByDeadLine);
            Employee.Employees.Sort(EmployeeServices.SortByWorkingHours);
            MessageDisplayer.DisplayMessage("\nPriority updated...");
            TaskScheduler scheduler = new TaskScheduler();
            scheduler.ScheduleTasks();
            MessageDisplayer.DisplayMessage("\nTasks Scheduled...\n");
            Utility.LogInFile($"Tasks Scheduled\n");
            Utility.ExportScheduledData();
        }

        /// <summary>
        /// Displays log to the user.
        /// </summary>
        public static void PerformViewLog()
        {
            MessageDisplayer.DisplayTitle("LOG FILE\n");
            using(StreamReader streamReader = new StreamReader("log.txt"))
            {
                if (streamReader.BaseStream.Length == 0)
                {
                    MessageDisplayer.DisplayWarningMessage("No Logs to read\n");
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
            DisplayChecker.DisplayCheckForEmployee();
            DisplayChecker.DisplayCheckForTasks();
            DisplayChecker.DisplayCheckForNotAvailableEmployees();
            DisplayChecker.DisplayCheckForScheduledTasks();
            DisplayChecker.DisplayCheckForUnscheduledTasks();
            DisplayChecker.DisplayCheckForEmployeesWithNoTasksScheduled();
            DisplayChecker.DisplayCheckForDeadLineExceededTasks();
            Utility.LogInFile("Viewed Report");
        }
    }
}