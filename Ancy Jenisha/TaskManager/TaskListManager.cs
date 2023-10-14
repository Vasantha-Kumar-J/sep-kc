namespace TaskManager
{
    /// <summary>
    /// Task Manager has the list of tasks.
    /// </summary>
    public class TaskListManager
    {
        /// <summary>
        /// List of TaskDetails.
        /// </summary>
        public static List<TaskDetails> ListOfTasks { get; set; } = new ();

        /// <summary>
        /// List of tasks sorted based on deadlines.
        /// </summary>
        public static List<TaskDetails> ListOfSortedTasks { get; set; } = new ();

        /// <summary>
        /// Sorts the list of tasks based on the deadlines.
        /// </summary>
        /// <param name="tasks">List of task details.</param>
        public static void SortByDeadline(List<TaskDetails> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                for(int j = i+1 ;j < tasks.Count; j++)
                {
                    if (tasks[i].DeadLine < tasks[j].DeadLine)
                    {
                        ListOfSortedTasks.Add(tasks[i]);
                    }
                }
            }
        }
    }
}