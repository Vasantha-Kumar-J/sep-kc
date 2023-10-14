namespace Employee_Task_Manager
{
    /// <summary>
    /// This is driver class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// User choice
        /// </summary>
        public enum UserChoice
        {
            /// <summary>
            /// Employee Details.
            /// </summary>
            EmployeeDetails = 1,

            /// <summary>
            /// Task Details.
            /// </summary>
            TaskDetails = 2,

            /// <summary>
            /// Task scheduling.
            /// </summary>
            TaskScheduling = 3,

            /// <summary>
            /// Exit.
            /// </summary>
            Exit = 4,
        }

        /// <summary>
        /// This is driver method.
        /// </summary>
        public static void Main()
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();
            TaskManagement taskManagement = new TaskManagement();
            TaskSchedulingAlgorithm taskScheduler = new TaskSchedulingAlgorithm();
            Console.WriteLine("Welcome to employee task manager");
            while (true)
            {
                Console.WriteLine("\nChoose the Operations\n1.Add employee details\n2.Add task details\n3.Schedule the task\n4.Exit\n");
                if (!int.TryParse(Console.ReadLine(), out int validUserChoice))
                {
                    Console.WriteLine("Enter valid userchoice");
                    continue;
                }

                switch ((UserChoice)validUserChoice)
                {
                    case UserChoice.EmployeeDetails:
                        employeeManagement.AddEmployee();
                        break;
                    case UserChoice.TaskDetails:
                        taskManagement.AddTask();
                        break;
                    case UserChoice.TaskScheduling:
                        if (taskManagement.TaskDetails.Count != 0 && employeeManagement.EmployeeDetails.Count != 0)
                        {
                            taskScheduler.ScheduleTask(employeeManagement, taskManagement);
                            taskScheduler.DisplayScheduledTask(taskScheduler.ScheduledTask);
                            taskScheduler.DisplayScheduledTask(taskScheduler.NonScheduledTask);
                        }
                        else
                        {
                            Console.WriteLine("Please add employee details and task details before scheduling task");
                        }

                        break;
                    case UserChoice.Exit:
                        return;
                    default:
                        Console.WriteLine("Choose any of the given options.");
                        break;
                }
            }
        }
    }
}