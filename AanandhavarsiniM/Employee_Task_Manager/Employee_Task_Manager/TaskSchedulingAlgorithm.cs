namespace Employee_Task_Manager
{
    using ConsoleTables;
    //using System.Linq;

    /// <summary>
    /// Manages Task Scheduling to employees.
    /// </summary>
    public class TaskSchedulingAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskSchedulingAlgorithm"/> class.
        /// </summary>
        public TaskSchedulingAlgorithm()
        {
            ScheduledTask = new List<Scheduler>();
            NonScheduledTask = new List<Scheduler>();
        }

        /// <summary>
        /// Gets or sets list of scheduled tasks.
        /// </summary>
        /// <value>
        /// Stores list of scheduled tasks.
        /// </value>
        public List<Scheduler> ScheduledTask { get; set; }

        /// <summary>
        /// Gets or sets list of scheduled tasks.
        /// </summary>
        /// <value>
        /// Stores list of scheduled tasks.
        /// </value>
        public List<Scheduler> NonScheduledTask { get; set; }

        /// <summary>
        /// Schedule the task.
        /// </summary>
        /// <param name="employeeManagement">oject of EmployeeManagement.</param>
        /// <param name="taskManagement">oject of TaskManagement.</param>
        public void ScheduleTask(EmployeeManagement employeeManagement, TaskManagement taskManagement)
        {
            /*var result = taskManagement.TaskDetails.OrderBy(task => task.Deadline).ToList().
                 Join(employeeManagement.EmployeeDetails, task => task.Skill, employee => employee.Skill, (task, employee) =>
                 new { task.TaskDescription, task.RequiredHours, task.Deadline, task.Skill, employee.EmployeeName });
            ConsoleTable table = new ConsoleTable("Task description", "Required Hours", "Deadline", "Skill", "Employee name");
            foreach (var task in result)
             {
                 table.AddRow(task.TaskDescription, task.RequiredHours, task.Deadline, task.Skill, task.EmployeeName);
             }

            Console.WriteLine(table.ToString());*/

            var orderedTaskByDeadline = taskManagement.TaskDetails.OrderBy(task => task.Deadline).ToList();
            foreach (var task in orderedTaskByDeadline)
            {
                bool isScheduled = false;
                Scheduler scheduler = new Scheduler();
                foreach (var employee in employeeManagement.EmployeeDetails)
                {
                    if (task.Skill == employee.Skill)
                    {
                        scheduler.Skill = employee.Skill;
                        scheduler.RequiredHours = task.RequiredHours;
                        scheduler.TaskDescription = task.TaskDescription;
                        scheduler.Deadline = task.Deadline;
                        scheduler.TaskAssignedEmployees.Add(employee);
                        isScheduled = true;
                    }
                }

                if (!isScheduled)
                {
                    scheduler.Skill = task.Skill;
                    scheduler.RequiredHours = task.RequiredHours;
                    scheduler.TaskDescription = task.TaskDescription;
                    scheduler.Deadline = task.Deadline;
                    scheduler.TaskAssignedEmployees = null;
                    NonScheduledTask.Add(scheduler);
                }

                ScheduledTask.Add(scheduler);
            }
        }

        /// <summary>
        /// Display scheduled task.
        /// </summary>
        /// <param name="schedulingTask">scheduling task</param>
        public void DisplayScheduledTask(List<Scheduler> schedulingTask)
        {
            ConsoleTable table = new ConsoleTable("Task description", "Required Hours", "Deadline", "Skill", "Employees name");
            foreach (var task in schedulingTask)
            {
                string employee = string.Empty;
                if (task.TaskAssignedEmployees != null)
                {
                    foreach (var taskAssignedemployee in task.TaskAssignedEmployees)
                    {
                        employee += taskAssignedemployee.EmployeeName + " ";
                    }
                }
                else
                {
                    employee = "No employees available";
                }

                table.AddRow(task.TaskDescription, task.RequiredHours, task.Deadline, task.Skill, employee);
            }

            Console.WriteLine(table.ToString());
        }
    }
}
