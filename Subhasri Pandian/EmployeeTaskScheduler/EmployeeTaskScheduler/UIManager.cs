namespace EmployeeTaskScheduler
{
    /// <summary>
    /// Entry point of the application Displays menu and starts performing tasks specified by the user.
    /// </summary>
    public class UIManager
    {
        public static void Main(string[] args)
        {
            TaskPerformer.PerformAllTasks();
            Console.ReadKey();
        }
    }
}