namespace SRAF
{
    public class Starter
    {
        public static void Main(string[] args)
        {
            TaskManager.Run(
                "1)Employee Management\n" +
                "2)TaskManagement\n" +
                "3)Scheduler\n" +
                "4)Report generator\n" +
                "5)Exit\n",
                new List<IManagement>()
                {
                    new EmployeeManagement(),
                });
        }
    }
}