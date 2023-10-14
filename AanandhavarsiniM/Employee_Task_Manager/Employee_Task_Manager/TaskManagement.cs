namespace Employee_Task_Manager
{
    /// <summary>
    /// Manage Task details.
    /// </summary>
    public class TaskManagement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManagement"/> class.
        /// </summary>
        public TaskManagement()
        {
            TaskDetails = new List<Task>();
        }

        /// <summary>
        /// Gets or sets list of task details.
        /// </summary>
        /// <value>
        /// List of task details.
        /// </value>
        public List<Task> TaskDetails { get; set; }

        /// <summary>
        /// Add task detail.
        /// </summary>
        public void AddTask()
        {
            GetDetailFromUser getDetailfromUser = new GetDetailFromUser();
            TaskDetails.Add(getDetailfromUser.GetTaskDetail());
            Console.WriteLine("Task detail Added!");
        }

        /// <summary>
        /// Display employee detail.
        /// </summary>
        public void DisplayEmployee()
        {
            foreach (Task task in TaskDetails)
            {
                Console.WriteLine($"{task.TaskDescription} {task.RequiredHours} {task.Deadline} {task.Skill}");
            }
        }
    }
}
