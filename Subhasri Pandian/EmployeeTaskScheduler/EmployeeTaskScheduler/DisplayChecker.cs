namespace EmployeeTaskScheduler
{
    /// <summary>
    /// DisplayChecker - Checks and calls the display function.
    /// </summary>
    public class DisplayChecker
    {
        /// <summary>
        /// Checks and Displays employees.
        /// </summary>
        public static void DisplayCheckForEmployee()
        {
            EmployeeServices accessServices = new EmployeeServices();
            MessageDisplayer.DisplayTitle("\nEMPLOYEES\n");
            if (!EmployeeServices.IsEmployeeAvailable())
            {
                accessServices.DisplayEmployees(Employee.Employees);
            }
            else
            {
                MessageDisplayer.DisplayWarningMessage("No employees availbale\n");
            }
        }

        /// <summary>
        /// Checks and displays tasks.
        /// </summary>
        public static void DisplayCheckForTasks()
        {
            TaskServices accessTaskService = new TaskServices();
            MessageDisplayer.DisplayTitle("\nTASKS\n");
            if (!TaskServices.IsTasksAvailable())
            {
                accessTaskService.DisplayTasks(Task.Tasks);
            }
            else
            {
                MessageDisplayer.DisplayWarningMessage("No tasks available\n");
            }
        }

        /// <summary>
        /// Checks and Displays Not Available Employees task.
        /// </summary>
        public static void DisplayCheckForNotAvailableEmployees()
        {
            EmployeeServices accessServices = new EmployeeServices();
            MessageDisplayer.DisplayTitle("\nUNAVAILABLE EMPLOYEES\n");
            if (TaskScheduler.NotAvailableEmployees.Count != 0)
            {
                accessServices.DisplayEmployees(TaskScheduler.NotAvailableEmployees);
            }
            else
            {
                MessageDisplayer.DisplayMessage("All the employees are available\n");
            }
        }

        /// <summary>
        /// Checks and displays Scheduled Tasks.
        /// </summary>
        public static void DisplayCheckForScheduledTasks()
        {
            TaskScheduler scheduler = new TaskScheduler();
            MessageDisplayer.DisplayTitle("\nSCHEDULED TASKS\n");
            if (TaskScheduler.ScheduledTasks.Count != 0)
            {
                scheduler.DisplayScheduledTasks();
            }
            else
            {
                MessageDisplayer.DisplayWarningMessage("No task has been scheduled! Try scheduling tasks.\n");
            }
        }

        /// <summary>
        /// Checks and Displays unscheduled tasks.
        /// </summary>
        public static void DisplayCheckForUnscheduledTasks()
        {
            TaskServices accessTaskService = new TaskServices();
            MessageDisplayer.DisplayTitle("\nTASKS UNSCHEDULED\n");
            if (TaskScheduler.TasksUnscheduled.Count != 0)
            {
                accessTaskService.DisplayUnscheduledTasks(TaskScheduler.TasksUnscheduled);
            }
            else
            {
                MessageDisplayer.DisplayWarningMessage("No tasks unscheduled\n");
            }
        }

        /// <summary>
        /// Checks and displays employees with no tasks scheduled.
        /// </summary>
        public static void DisplayCheckForEmployeesWithNoTasksScheduled()
        {
            EmployeeServices accessServices = new EmployeeServices();
            MessageDisplayer.DisplayTitle("\nEMPLOYEES WITH NO TASKS SCHEDULED\n");
            if (TaskScheduler.EmployeesWithNoTasksScheduled.Count != 0)
            {
                accessServices.DisplayUnAssignedEmployees(TaskScheduler.EmployeesWithNoTasksScheduled);
            }
            else
            {
                MessageDisplayer.DisplayMessage("All the employees have tasks scheduled\n");
            }
        }

        /// <summary>
        /// Checks and displays deadline exceeded tasks
        /// </summary>
        public static void DisplayCheckForDeadLineExceededTasks()
        {
            TaskServices accessServices = new TaskServices();
            MessageDisplayer.DisplayTitle("\nDEADLINE EXCEEDED TASKS\n");
            if (TaskScheduler.DeadLineExceededTasks.Count != 0)
            {
                accessServices.DisplayTasks(TaskScheduler.DeadLineExceededTasks);
            }
            else
            {
                MessageDisplayer.DisplayMessage("No task exceeds the deadline\n");
            }
        }
    }
}