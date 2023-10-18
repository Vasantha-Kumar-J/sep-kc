namespace EmployeeManagerAndTaskScheduler
{
    public class Starter
    {
        public static void Main(string[] args)
        {
           new TaskSchedulingApplication(new Scheduler()).Start();
        }
    }
}