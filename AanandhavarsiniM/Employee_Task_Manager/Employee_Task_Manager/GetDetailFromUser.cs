namespace Employee_Task_Manager
{
    /// <summary>
    /// Get employee details from user
    /// </summary>
    public class GetDetailFromUser
    {
        /// <summary>
        /// Get Employee detail from user.
        /// </summary>
        /// <returns>Returns employee oject.</returns>
        public Employee GetEmployeeDetail()
        {
            string employeeName;
            double workinghours;
            string availability;
            string skill;
            while (true)
            {
                Console.Write("Enter employee name: ");
                employeeName = Console.ReadLine();
                if (string.IsNullOrEmpty(employeeName))
                {
                    Console.WriteLine("Employee name cannot be null or empty. Please enter valid name.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter employee working hours: ");
                if (!double.TryParse(Console.ReadLine(), out workinghours))
                {
                    Console.WriteLine("Enter valid working hours.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter Y if employee available and N for not available: ");
                availability = Console.ReadLine();
                if (string.IsNullOrEmpty(availability))
                {
                    Console.WriteLine("Employee status cannot be empty or null. Enter valid status.");
                    continue;
                }

                if (availability.Contains("Y", StringComparison.OrdinalIgnoreCase))
                {
                    availability = "Available";
                }

                availability = "Not Available";

                break;
            }

            while (true)
            {
                Console.Write("Enter employee skill: ");
                skill = Console.ReadLine();
                if (string.IsNullOrEmpty(skill))
                {
                    Console.WriteLine("Employee skill cannot be null or empty. Please enter valid skill.");
                    continue;
                }

                break;
            }

            return new Employee { EmployeeName = employeeName, Availability = availability, WorkingHours = workinghours, Skill = skill };
        }

        /// <summary>
        /// Get task detail from user
        /// </summary>
        /// <returns>Returns task object</returns>
        public Task GetTaskDetail()
        {
            string taskDescription;
            double requiredhours;
            DateTime deadline;
            string skill;
            while (true)
            {
                Console.Write("Enter task description: ");
                taskDescription = Console.ReadLine();
                if (string.IsNullOrEmpty(taskDescription))
                {
                    Console.WriteLine("Task description cannot be null or empty. Please enter valid description.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter required hours to complete task: ");
                if (!double.TryParse(Console.ReadLine(), out requiredhours))
                {
                    Console.WriteLine("Enter valid number of hours needed to complete task.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter deadline in format(dd/MM/yyyy)");
                if (!DateTime.TryParse(Console.ReadLine(), out deadline))
                {
                    Console.WriteLine("Enter deadline in valid format.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter skill needed for task: ");
                skill = Console.ReadLine();
                if (string.IsNullOrEmpty(skill))
                {
                    Console.WriteLine("Employee skill cannot be null or empty. Please enter valid skill.");
                    continue;
                }

                break;
            }

            return new Task { TaskDescription = taskDescription, RequiredHours = requiredhours, Deadline = deadline, Skill = skill };
        }
    }
}
