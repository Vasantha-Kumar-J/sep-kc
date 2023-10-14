using ConsoleTables;

namespace EmployeeTaskScheduler
{
    public class TaskScheduler
    {
        public static List<(Employee, Task)> ScheduledTasks { get; set; } = new List<(Employee, Task)> ();

        public static List<Employee> NotAvailableEmployees { get; set; } = new List<Employee> ();

        public static List<Employee> EmployeesWithNoTasksScheduled { get; set; } = new List<Employee>();

        public static List<Task> TasksUnscheduled { get; set; } = new List<Task>();

        /// <summary>
        /// Schedules tasks to employees according to their skills and working hours.
        /// </summary>
        public void ScheduleTasks()
        {
            foreach (Employee employee in Employee.Employees)
            {
                bool assignedFlag = false;
                if(employee.AvailabilityOfEmployee == "no")
                {
                    NotAvailableEmployees.Add (employee);
                    continue;
                }

                foreach (Task tasks in Task.Tasks)
                {
                    if(assignedFlag == true)
                    {
                        break;
                    }
                    if (employee.Skills.Equals(tasks.Skills))
                    {
                        if (employee.WorkingHours >= tasks.RequiredHours)
                        {
                            ScheduledTasks.Add((employee, tasks));
                            assignedFlag = true;
                            tasks.Assigned = true;
                        }
                    }
                }
                if(assignedFlag == false)
                {
                    EmployeesWithNoTasksScheduled.Add (employee);
                }
            }
        }

        /// <summary>
        /// Displays tasks scheduled with employees assigned.
        /// </summary>
        public void DisplayScheduledTasks()
        {
            ConsoleTable table = new ConsoleTable("Employee Name", "Working Hours", "Skills"," Skills Required","Description","DeadLine","Required Hours");
            foreach ((Employee,Task) tasksScheduled in ScheduledTasks)
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
            table.Write();
        }
    }
}