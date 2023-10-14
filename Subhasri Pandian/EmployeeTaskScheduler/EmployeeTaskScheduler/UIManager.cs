namespace EmployeeTaskScheduler
{
    /// <summary>
    /// Entry point of the application Displays menu and starts performing tasks specified by the user.
    /// </summary>
    public class UIManager
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nEMPLOYEE TASK SCHEDULER\n");
            TaskPerformer.PerformAllTasks();
            Console.ReadKey();
        }
    }
}