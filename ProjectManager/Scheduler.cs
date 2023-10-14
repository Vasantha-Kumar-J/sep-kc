using System.Threading.Tasks;

namespace ProjectManager
{
    public class Scheduler
    {
        public static void ScheduleTaskToEmployees(Task task, List<Employee> availableEmployees)
        {
            foreach (var availableEmployee in availableEmployees)
            {
                foreach (var employee in EmployeeDataManager.EmployeeList)
                {
                    if (employee.EmployeeId == availableEmployee.EmployeeId)
                    {
                        employee.Task = task.TaskName;
                        employee.EmployeeStatus = false;
                    }
                }
            }
        }

        public static bool IsResourceAvailable(int taskHours, DateOnly taskDeadline, List<Employee> employees)
        {
            int totalWorkHoursOfEmployee = 0;
            int totalWorkDone = taskHours;
            foreach (var employee in employees)
            {
                totalWorkHoursOfEmployee += employee.EmployeeWorkingHours;
            }

            for (var currentDate = DateOnly.FromDateTime(DateTime.Now); taskDeadline > currentDate; currentDate.AddDays(1))
            {
                if (totalWorkHoursOfEmployee >= totalWorkDone)
                {
                    return true;
                }

                totalWorkDone -= totalWorkHoursOfEmployee;
            }

            return false;
        }

        public static List<Employee> GetAvailableEmployees(string skillRequired)
        {
            List<Employee> availableEmployee = new List<Employee>();
            foreach (var employee in EmployeeDataManager.EmployeeList)
            {
                if (employee.EmployeeStatus && employee.EmployeeSkills == skillRequired)
                {
                    availableEmployee.Add(employee);
                }
            }

            return availableEmployee;
        }

        public static void ScheduleManager()
        {
            foreach (var task in TasksDataManager.TasksList)
            {
                if (!task.Scheduled)
                {
                    List<Employee> availableEmployees = GetAvailableEmployees(task.TaskSkill);

                    if (IsResourceAvailable(task.TaskHours, task.TaskDeadline, availableEmployees))
                    {
                        ScheduleTaskToEmployees(task, availableEmployees);
                        task.Scheduled = true;
                        Utility.DisplayMessageInSpecificColor($"Employees have been scheduled with the task : {task.TaskName}", "Green");
                    }
                    else
                    {
                        Utility.DisplayMessageInSpecificColor($"Insufficient Employees. Need more resources to set up task : {task.TaskName}.", "Red");
                    }
                }
            }
        }
    }
}
