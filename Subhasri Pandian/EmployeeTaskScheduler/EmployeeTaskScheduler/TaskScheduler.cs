using ConsoleTables;
using System.Data;

namespace EmployeeTaskScheduler
{
    /// <summary>
    /// Schedules and displays tasks.
    /// </summary>
    public class TaskScheduler
    {
        public static List<(Employee, Task, DateTime)> ScheduledTasks { get; set; } = new List<(Employee, Task, DateTime)> ();

        public static List<Employee> NotAvailableEmployees { get; set; } = new List<Employee> ();

        public static List<Employee> EmployeesWithNoTasksScheduled { get; set; } = new List<Employee>();

        public static List<Task> TasksUnscheduled { get; set; } = new List<Task>();

        public static List<Task> DeadLineExceededTasks { get; set; } = new List<Task> ();

        public static int i = 0;

        /// <summary>
        /// Schedules tasks to employees according to their skills and working hours.
        /// </summary>
        public void ScheduleTasks()
        {
            NotAvailableEmployees.Clear ();
            EmployeesWithNoTasksScheduled.Clear ();
            foreach (Employee employee in Employee.Employees)
            {
                employee.RemainingHours = employee.WorkingHours;
                if(employee.AvailabilityOfEmployee == "no")
                {
                    NotAvailableEmployees.Add (employee);
                    continue;
                }
                RequirementChecker(employee);
                if(employee.Assigned == false)
                {
                    EmployeesWithNoTasksScheduled.Add (employee);
                }
            }
            UnscheduledTaskAssigner();
        }

        /// <summary>
        /// Displays tasks scheduled with employees assigned.
        /// </summary>
        public void DisplayScheduledTasks()
        {
            ConsoleTable table = new ConsoleTable("Employee Name", "Working Hours", "Skills"," Skills Required","Task Description","Task DeadLine","Assigned For","Required Hours");
            foreach ((Employee, Task, DateTime) tasksScheduled in ScheduledTasks)
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
               ) ;
            }
            table.Write();
        }

        /// <summary>
        /// Checks employee and task availability.
        /// </summary>
        /// <param name="employee">Employee object parsed.</param>
        public void RequirementChecker(Employee employee)
        {
            IEnumerable<Task> tasksUnscheduled = Task.Tasks.Where(task => task.Assigned == false);
            foreach (Task tasks in tasksUnscheduled)
            {
                if (employee.RemainingHours == 0)
                {
                    employee.Assigned = true;
                    break;
                }
                if (tasks.RemainingHours == 0)
                {
                    tasks.Assigned = true;
                    continue;
                }
                TaskAssigner(employee, tasks);
            }
        }

        /// <summary>
        /// Assigns task to the employee and changes the status of both task and employee.
        /// </summary>
        /// <param name="employee">Employee object available for assignment.</param>
        /// <param name="tasks">Task object available for assignment.</param>
        public void TaskAssigner(Employee employee, Task tasks)
        {
            if (employee.Skills.ToLower().Equals(tasks.Skills.ToLower()))
            {
                ScheduledTasks.Add((employee, tasks, DateTime.Now.AddDays(i)));
                if (employee.RemainingHours > tasks.RemainingHours)
                {
                    employee.RemainingHours -= tasks.RemainingHours;
                    tasks.RemainingHours = 0;
                    tasks.Assigned = true;
                }
                else if (employee.RemainingHours < tasks.RemainingHours)
                {
                    tasks.RemainingHours -= employee.RemainingHours;
                    employee.RemainingHours = 0;
                    employee.Assigned = true;
                }
                else
                {
                    employee.RemainingHours = 0;
                    tasks.RemainingHours = 0;
                    tasks.Assigned = true;
                    employee.Assigned = true;
                }
            }
        }

        /// <summary>
        /// Checks and assigns unscheduled task if deadline date is available.
        /// </summary>
        public void UnscheduledTaskAssigner()
        {
            TaskScheduler.TasksUnscheduled.Clear();
            foreach (Task task in Task.Tasks)
            {
                task.Days -= 1;
            }
            TaskScheduler.TasksUnscheduled.AddRange(Task.Tasks.Where(task => task.Assigned == false));
            IEnumerable<Task> TaskAssignmentForNextDay = TaskScheduler.TasksUnscheduled.Where(task => task.Days >= 0);
            if (TaskAssignmentForNextDay.Count() > 0)
            {
                i++;
                ScheduleTasks();
            }
        }
    }
}