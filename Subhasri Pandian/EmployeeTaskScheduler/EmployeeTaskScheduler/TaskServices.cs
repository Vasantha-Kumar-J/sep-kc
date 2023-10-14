using ConsoleTables;

namespace EmployeeTaskScheduler
{
    public class TaskServices
    {
        /// <summary>
        /// GetTaskDetails - gets the task details from the user.
        /// </summary>
        /// <returns>Returns object of the task class.</returns>
        public Task GetTaskDetails()
        {
            Task task = new Task();
            task.Description = "description of the task".GetValidInput<string>();
            task.RequiredHours = "hours required to complete the task".GetValidInput<double>();
            task.DeadlineDate = "deadline date for the task format(mm-dd-yyyy)".GetValidInput<DateTime>();
            task.Skills = "skills required to complete the task".GetValidInput<string>();
            return task;
        }

        /// <summary>
        /// GetFileTaskDetails - gets the details of the task from the file.
        /// </summary>
        public void GetFileTaskDetails()
        {
            using (StreamReader streamReader = new StreamReader("task.txt"))
            {
                string[] dataLines = streamReader.ReadToEnd().Split(new char[] { '\n', '\r' });
                foreach (string line in dataLines)
                {
                    string[] dataRead = line.Split(' ');
                    Task task = new Task();
                    if (dataRead.Length == 4)
                    {
                        task.Description = dataRead[0];
                        task.RequiredHours = (double)Convert.ChangeType(dataRead[1], typeof(double));
                        task.DeadlineDate = (DateTime)Convert.ChangeType(dataRead[2], typeof(DateTime));
                        task.Skills = dataRead[3];
                        Task.Tasks.Add(task);
                    }
                }
            }
        }

        /// <summary>
        /// Displays all tasks.
        /// </summary>
        /// <param name="tasks"></param>
        public void DisplayTasks(List<Task> tasks)
        {
            ConsoleTable table = new ConsoleTable("Task Description", "Required Hours", "Skills", "DeadLine Date");
            foreach (Task task in tasks)
            {
                table.AddRow(task.Description, task.RequiredHours, task.Skills, task.DeadlineDate.Date);
            }
            table.Write();
        }

        /// <summary>
        /// Checks availability of tasks.
        /// </summary>
        /// <returns>Returns true if empty else false.</returns>
        public static bool IsTasksAvailable()
        {
            return Task.Tasks.Any() ? false : true;
        }


        /// <summary>
        /// Sorts tasks based on deadlines.
        /// </summary>
        /// <param name="task1">First object to be compared.</param>
        /// <param name="task2">Second object to be compared</param>
        /// <returns>Returns integer returned by compareTo operation.</returns>
        public static int SortByDeadLine(Task task1, Task task2)
        {
            return task1.DeadlineDate.CompareTo(task2.DeadlineDate);
        }
    }
}