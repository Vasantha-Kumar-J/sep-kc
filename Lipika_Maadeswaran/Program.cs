
namespace TaskScheduler
{
    /// <summary>
    /// Driver class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            taskManager.AddingTasks();
            taskManager.AddingEmployees();
            taskManager.AddTaskDataFromFile();
            taskManager.AddEmployeeDataFromFile();
            taskManager.AddTaskFromUser();
            taskManager.DisplayAvailablity();
            taskManager.AssignTaskToEmployee();
            Console.WriteLine("Hello, World!");
        }
    }
}